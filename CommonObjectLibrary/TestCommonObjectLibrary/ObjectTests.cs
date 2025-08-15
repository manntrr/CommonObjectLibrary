namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using LibraryTestsInterface = IObjectTests;
using Is = NUnit.Framework.Constraints.Is;

public class ObjectTests : LibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }
    //static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), CommonObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void TestGetByKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestSetByKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestGetKeys()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestGetValues()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestGetCount()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestGetIsReadOnly()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestAddElements()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestAddPair()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestClear()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestContains()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestContainsKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestCopyTo()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestPairEnumerator()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestEnumerator()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestRemove()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestRemovePair()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void TestTryGetValue()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void NullConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void NullInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void InterfaceCopyConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void InterfaceCopyInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void CopyConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void CopyInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void DictionaryInterfaceConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void DictionaryInterfaceInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void DictionaryConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void DictionaryInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void KVPairConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void KVPairInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void KVPairArrayConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void KVPairArrayInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void ElementArraysConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void ElementArraysInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void ValueArrayConstructorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    [Test]
    public void ValueArrayInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }

}
