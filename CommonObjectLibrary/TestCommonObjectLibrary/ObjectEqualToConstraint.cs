namespace NUnit.Framework.Constraints;

using Object = CommonObjectLibrary.CommonObject;

public class ObjectEqualToConstraint : Constraint
{
    //public Object Context { get; }
    public Object Expected { get; }
    public override string Description { get => $"Common Object Equal expected value: {Expected}"; }
    public ObjectEqualToConstraint(/*Object context, /**/Object expected)
    {
        //Context = context;
        Expected = expected;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<Object>());
            Assert.That(actual, Is.Not.Null);
            var obj = actual as Object;
            Assert.That(obj, Is.Not.Null);
            Assert.That(obj, Is.InstanceOf<Object>());
            Assert.That(Expected.Count, Is.EqualTo(obj.Count));
            foreach (string key in Expected.GetKeys())
            {
                Assert.That(obj.ContainsKey(key), Is.True);
            }
            foreach (string key in obj.GetKeys())
            {
                Assert.That(Expected.ContainsKey(key), Is.True);
                Assert.That(Expected[key], Is.EqualTo(obj[key]));
            }
        }
        catch (Exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}