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
            isMatch = false; //TODO: complete the test for equality of the instance
            /*
            Assert.That(commonObject, Is.GenresCountEqual(_expectedValue.Count));
            foreach (KeyValuePair<string, Genre> _genre in _expectedValue)
            {
                Assert.That(commonObject, Is.GenresContainGenre(_context, _genre.Value));
            }
            /**/
        }
        catch (Exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}