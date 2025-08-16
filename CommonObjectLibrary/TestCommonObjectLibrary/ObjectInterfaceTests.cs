namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using LibraryTestsInterface = IObjectInterfaceTests;
using Is = NUnit.Framework.Constraints.Is;
using System.Collections;

public class ObjectInterfaceTests : LibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }
    static readonly TestCaseData[] StaticGetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetByKeyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetByKeyTestCases))]
    public void StaticGetByKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticSetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticSetByKeyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticSetByKeyTestCases))]
    public void StaticSetByKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticGetKeysTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetKeysTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetKeysTestCases))]
    public void StaticGetKeysTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticGetValuesTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetValuesTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetValuesTestCases))]
    public void StaticGetValuesTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticGetCountTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetCountTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetCountTestCases))]
    public void StaticGetCountTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, int caseExpectedCount)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticGetIsReadOnlyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetIsReadOnlyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetIsReadOnlyTestCases))]
    public void StaticGetIsReadOnlyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticAddElementsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddElementsTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticAddElementsTestCases))]
    public void StaticAddElementsTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticAddPairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddPairTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticAddPairTestCases))]
    public void StaticAddPairTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticClearTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticClearTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticClearTestCases))]
    public void StaticClearTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticContainsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticContainsTestCases))]
    public void StaticContainsTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticContainsKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsKeyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticContainsKeyTestCases))]
    public void StaticContainsKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticCopyToTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyToTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticCopyToTestCases))]
    public void StaticCopyToTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticPairEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticPairEnumeratorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticPairEnumeratorTestCases))]
    public void StaticPairEnumeratorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticEnumeratorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticEnumeratorTestCases))]
    public void StaticEnumeratorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticRemoveTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemoveTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticRemoveTestCases))]
    public void StaticRemoveTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticRemovePairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemovePairTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticRemovePairTestCases))]
    public void StaticRemovePairTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticTryGetValueTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticTryGetValueTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticTryGetValueTestCases))]
    public void StaticTryGetValueTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticNullInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticNullInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticNullInitializorTestCases))]
    public void StaticNullInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticInterfaceCopyInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticInterfaceCopyInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticInterfaceCopyInitializorTestCases))]
    public void StaticInterfaceCopyInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticCopyInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticCopyInitializorTestCases))]
    public void StaticCopyInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticDictionaryInterfaceInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInterfaceInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializorTestCases))]
    public void StaticDictionaryInterfaceInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticDictionaryInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInitializorTestCases))]
    public void StaticDictionaryInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticKVPairInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticKVPairInitializorTestCases))]
    public void StaticKVPairInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticKVPairArrayInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairArrayInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticKVPairArrayInitializorTestCases))]
    public void StaticKVPairArrayInitializorTest(System.Object caseProvidedObjectInstance, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticElementArraysInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticElementArraysInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticElementArraysInitializorTestCases))]
    public void StaticElementArraysInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
    static readonly TestCaseData[] StaticValueArrayInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticValueArrayInitializorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticValueArrayInitializorTestCases))]
    public void StaticValueArrayInitializorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
    }
}
