namespace NUnit.Framework.Constraints;

using ObjectInterface = CommonObjectLibrary.ICommonObject;

public class ObjectInterfaceEqualToConstraint : Constraint
{
    //public ObjectInterface Context { get; }
    public ObjectInterface Expected { get; }
    public override string Description { get => $"Common ObjectInterface Equal expected value: {Expected}"; }
    public ObjectInterfaceEqualToConstraint(/*ObjectInterface context,*/ ObjectInterface expected)
    {
        //Context = context;
        Expected = expected;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<ObjectInterface>());
            Assert.That(actual, Is.Not.Null);
            var obj = actual as ObjectInterface;
            Assert.That(obj, Is.Not.Null);
            Assert.That(obj, Is.InstanceOf<ObjectInterface>());
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