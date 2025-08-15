namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using CommonObjectLibraryTestsInterface = ICommonObjectLibraryTests;

public class CommonObjectInterfaceTests : CommonObjectLibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }

    //static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), CommonObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void TestCommonObjectLibrary()
    {
        Object obj = new();
        Assert.That(/*Is./**/Equals(obj, obj));
    }

    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void NullConstructorTest()
    {
        Object obj = new();
        Assert.Pass();
    }
}
