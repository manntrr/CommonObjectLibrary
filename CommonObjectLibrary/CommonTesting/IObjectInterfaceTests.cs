using System.Collections;

namespace TestCommonObjectLibrary;

public interface IObjectInterfaceTests
{
    static readonly TestCaseData[] StaticGetByKeyTestCases = [],
        StaticSetByKeyTestCases = [],
        StaticGetKeysTestCases = [],
        StaticGetValuesTestCases = [],
        StaticGetCountTestCases = [],
        StaticGetIsReadOnlyTestCases = [],
        StaticAddElementsTestCases = [],
        StaticAddPairTestCases = [],
        StaticClearTestCases = [],
        StaticContainsTestCases = [],
        StaticContainsKeyTestCases = [],
        StaticCopyToTestCases = [],
        StaticPairEnumeratorTestCases = [],
        StaticEnumeratorTestCases = [],
        StaticRemoveTestCases = [],
        StaticRemovePairTestCases = [],
        StaticTryGetValueTestCases = [],
        StaticNullInitializorTestCases = [],
        StaticInterfaceCopyInitializorTestCases = [],
        StaticCopyInitializorTestCases = [],
        StaticDictionaryInterfaceInitializorTestCases = [],
        StaticDictionaryInitializorTestCases = [],
        StaticKVPairInitializorTestCases = [],
        StaticKVPairArrayInitializorTestCases = [],
        StaticElementArraysInitializorTestCases = [],
        StaticValueArrayInitializorTestCases = [];
    [SetUp]
    public void Setup();
    [Test]
    [TestCaseSource(nameof(StaticGetByKeyTestCases))]
    public void StaticGetByKeyTest(Object caseProvidedObjectInstance, Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticSetByKeyTestCases))]
    public void StaticSetByKeyTest(Object caseProvidedObjectInstance, Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticGetKeysTestCases))]
    public void StaticGetKeysTest(Object caseProvidedObjectInstance, Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [Test]
    [TestCaseSource(nameof(StaticGetValuesTestCases))]
    public void StaticGetValuesTest(Object caseProvidedObjectInstance, Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [Test]
    [TestCaseSource(nameof(StaticGetCountTestCases))]
    public void StaticGetCountTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, int caseExpectedCount);
    [Test]
    [TestCaseSource(nameof(StaticGetIsReadOnlyTestCases))]
    public void StaticGetIsReadOnlyTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [Test]
    [TestCaseSource(nameof(StaticAddElementsTestCases))]
    public void StaticAddElementsTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticAddPairTestCases))]
    public void StaticAddPairTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticClearTestCases))]
    public void StaticClearTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject);
    [Test]
    [TestCaseSource(nameof(StaticContainsTestCases))]
    public void StaticContainsTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult);
    [Test]
    [TestCaseSource(nameof(StaticContainsKeyTestCases))]
    public void StaticContainsKeyTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult);
    [Test]
    [TestCaseSource(nameof(StaticCopyToTestCases))]
    public void StaticCopyToTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(StaticPairEnumeratorTestCases))]
    public void StaticPairEnumeratorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator);
    [Test]
    [TestCaseSource(nameof(StaticEnumeratorTestCases))]
    public void StaticEnumeratorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator);
    [Test]
    [TestCaseSource(nameof(StaticRemoveTestCases))]
    public void StaticRemoveTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(StaticRemovePairTestCases))]
    public void StaticRemovePairTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(StaticTryGetValueTestCases))]
    public void StaticTryGetValueTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticNullInitializorTestCases))]
    public void StaticNullInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticInterfaceCopyInitializorTestCases))]
    public void StaticInterfaceCopyInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticCopyInitializorTestCases))]
    public void StaticCopyInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializorTestCases))]
    public void StaticDictionaryInterfaceInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInitializorTestCases))]
    public void StaticDictionaryInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticKVPairInitializorTestCases))]
    public void StaticKVPairInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticKVPairArrayInitializorTestCases))]
    public void StaticKVPairArrayInitializorTest(Object caseProvidedObjectInstance, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticElementArraysInitializorTestCases))]
    public void StaticElementArraysInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticValueArrayInitializorTestCases))]
    public void StaticValueArrayInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
}