namespace TestCommonObjectLibrary;

using CommonObjectLibrary;

public class UnitTestCommonObjectLibrary
{
    [SetUp]
    public void Setup()
    {
    }

    //static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void TestCommonObjectLibrary()
    {
        CommonObject commonObject = new();
        Assert.Pass();
    }
}
