namespace NUnit.Framework.Constraints;

using ObjectInterface = CommonObjectLibrary.ICommonObject;

public class ObjectInterfaceEqualConstraint : Constraint
{
    //public ObjectInterface Context { get; }
    public ObjectInterface Expected { get; }
    public override string Description { get => $"Common ObjectInterface Equal expected value: {Expected}"; }
    public ObjectInterfaceEqualConstraint(/*ObjectInterface context,*/ ObjectInterface expected)
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
            isMatch = false; //TODO: complete the test for equality of the instance
            /*
            Assert.That(commonObject, Is.GenresCountEqual(_expectedValue.Count));
            foreach (KeyValuePair<string, Genre> _genre in _expectedValue)
            {
                Assert.That(commonObject, Is.GenresContainGenre(_context, _genre.Value));
            }
            /**/
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}