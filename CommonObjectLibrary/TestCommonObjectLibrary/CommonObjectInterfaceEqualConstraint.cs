using CommonObjectLibrary;
using CommonObject = CommonObjectLibrary.CommonObject;
using CommonObjectInterface = CommonObjectLibrary.ICommonObject;

namespace NUnit.Framework.Constraints;

public class CommonObjectInterfaceEqualConstraint : Constraint
{
    public CommonObjectInterface Context { get; }
    public CommonObjectInterface Expected { get; }
    public override string Description { get => $"CommonObjectInterface Equal expected value: {Expected}"; }
    public CommonObjectInterfaceEqualConstraint(CommonObjectInterface context, CommonObjectInterface expected)
    {
        Context = context;
        Expected = expected;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<CommonObjectInterface>());
            Assert.That(actual, Is.Not.Null);
            var commonObject = actual as CommonObjectInterface;
            Assert.That(commonObject, Is.Not.Null);
            Assert.That(commonObject, Is.InstanceOf<CommonObjectInterface>());
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