using CommonObjectLibrary;
using CommonObject = CommonObjectLibrary.CommonObject;
using CommonObjectInterface = CommonObjectLibrary.ICommonObject;

namespace NUnit.Framework.Constraints;

public class CommonObjectEqualConstraint : Constraint
{
    public CommonObject Context { get; }
    public CommonObject Expected { get; }
    public override string Description { get => $"CommonObject Equal expected value: {Expected}"; }
    public CommonObjectEqualConstraint(CommonObject context, CommonObject expected)
    {
        Context = context;
        Expected = expected;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<CommonObject>());
            Assert.That(actual, Is.Not.Null);
            var commonObject = actual as CommonObject;
            Assert.That(commonObject, Is.Not.Null);
            Assert.That(commonObject, Is.InstanceOf<CommonObject>());
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