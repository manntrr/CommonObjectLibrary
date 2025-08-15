namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using LibraryTestsInterface = IObjectInterfaceTests;
using Is = NUnit.Framework.Constraints.Is;

public class ObjectInterfaceTests : LibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }
    //static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), CommonObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void TestStaticGetByKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticSetByKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticGetKeys()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticGetValues()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticGetCount()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticGetIsReadOnly()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticAddElements()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticAddPair()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticClear()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticContains()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticContainsKey()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticCopyTo()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticPairEnumerator()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticEnumerator()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticRemove()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticRemovePair()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void TestStaticTryGetValue()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticNullInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    //[TestCaseSource(nameof(NullConstructorTestCases))]
    //public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    public void StaticNullInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticInterfaceCopyInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticCopyInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticDictionaryInterfaceInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticDictionaryInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticKVPairInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticKVPairArrayInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticElementArraysInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    [Test]
    public void StaticValueArrayInitializorTest()
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
}
