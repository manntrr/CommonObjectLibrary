namespace NUnit.Framework.Constraints;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;

public static class LibraryConstraints
{
    public static ObjectEqualConstraint Equal(/*Object context, /**/Object expected)
    {
        return new ObjectEqualConstraint(/*context, /**/expected);
    }
    public static ObjectInterfaceEqualConstraint Equal(/*ObjectInterface context, /**/ObjectInterface expected)
    {
        return new ObjectInterfaceEqualConstraint(/*context, /**/expected);
    }
    /*
    public static GenresContainGenreConstraint GenresContainGenre(_Heroes context, Genre expected)
    {
        return new GenresContainGenreConstraint(context, expected);
    }
    public static GenresCountEqualConstraint GenresCountEqual(int expected)
    {
        return new GenresCountEqualConstraint(expected);
    }
    public static GenresCampaignKeysEqualConstraint GenresCampaignKeysEqual(Heroes.Heroes context, CampaignKeySet expected)
    {
        return new GenresCampaignKeysEqualConstraint(context, expected);
    }
    public static GenresPlayerKeysEqualConstraint GenresPlayerKeysEqual(Heroes.Heroes context, PlayerKeySet expected)
    {
        return new GenresPlayerKeysEqualConstraint(context, expected);
    }
    public static GenresGameMasterKeysEqualConstraint GenresGameMasterKeysEqual(Heroes.Heroes context, GameMasterKeySet expected)
    {
        return new GenresGameMasterKeysEqualConstraint(context, expected);
    }
    /**/
}
