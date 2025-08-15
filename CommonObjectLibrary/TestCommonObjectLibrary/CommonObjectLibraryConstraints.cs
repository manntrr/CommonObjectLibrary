using CommonObjectLibrary;
using CommonObject = CommonObjectLibrary.CommonObject;
using CommonObjectInterface = CommonObjectLibrary.ICommonObject;

namespace NUnit.Framework.Constraints;

public static class CommonObjectLibraryConstraints
{
    public static CommonObjectEqualConstraint CommonObjectEqual(CommonObject context, CommonObject expected)
    {
        return new CommonObjectEqualConstraint(context, expected);
    }
    public static CommonObjectInterfaceEqualConstraint CommonObjectInterfaceEqual(CommonObjectInterface context, CommonObjectInterface expected)
    {
        return new CommonObjectInterfaceEqualConstraint(context, expected);
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
