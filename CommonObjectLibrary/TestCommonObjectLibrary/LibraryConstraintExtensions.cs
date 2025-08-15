namespace NUnit.Framework.Constraints;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;

public static class LibraryConstraintExtensions
{
    public static ObjectEqualToConstraint EqualTo(this ConstraintExpression expression, /*Object context, /**/Object expected)
    {
        var constraint = new ObjectEqualToConstraint(/*context, /**/expected);
        expression.Append(constraint);
        return constraint;
    }
    public static ObjectInterfaceEqualToConstraint EqualTo(this ConstraintExpression expression, /*ObjectInterface context, /**/ObjectInterface expected)
    {
        var constraint = new ObjectInterfaceEqualToConstraint(/*context, /**/expected);
        expression.Append(constraint);
        return constraint;
    }
    /*
    public static GenresContainGenreConstraint GenresContainGenre(this ConstraintExpression expression, _Heroes context, Genre expected)
    {
        var constraint = new GenresContainGenreConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresCountEqualConstraint GenresCountEqual(this ConstraintExpression expression, int expected)
    {
        var constraint = new GenresCountEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresCampaignKeysEqualConstraint GenresCampaignKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, CampaignKeySet expected)
    {
        var constraint = new GenresCampaignKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresPlayerKeysEqualConstraint GenresPlayerKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, PlayerKeySet expected)
    {
        var constraint = new GenresPlayerKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresGameMasterKeysEqualConstraint GenresGameMasterKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, GameMasterKeySet expected)
    {
        var constraint = new GenresGameMasterKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    /**/
}