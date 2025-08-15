using CommonObjectLibrary;
using CommonObject = CommonObjectLibrary.CommonObject;
using CommonObjectInterface = CommonObjectLibrary.ICommonObject;

namespace NUnit.Framework.Constraints;

public static class CommonObjectLibraryConstraintExtensions
{
    public static CommonObjectEqualConstraint CommonObjectEqual(this ConstraintExpression expression, CommonObject context, CommonObject expected)
    {
        var constraint = new CommonObjectEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CommonObjectInterfaceEqualConstraint CommonObjectInterfaceEqual(this ConstraintExpression expression, CommonObjectInterface context, CommonObjectInterface expected)
    {
        var constraint = new CommonObjectInterfaceEqualConstraint(context, expected);
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