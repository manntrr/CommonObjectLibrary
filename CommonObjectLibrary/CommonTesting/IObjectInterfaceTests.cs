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
    [TestCaseSource(nameof(StaticGetByKeyTestCases))]
    public void StaticGetByKeyTest(Object caseProvidedObjectInstance, Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticSetByKeyTestCases))]
    public void StaticSetByKeyTest(Object caseProvidedObjectInstance, Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticGetKeysTestCases))]
    public void StaticGetKeysTest(Object caseProvidedObjectInstance, Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [TestCaseSource(nameof(StaticGetValuesTestCases))]
    public void StaticGetValuesTest(Object caseProvidedObjectInstance, Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [TestCaseSource(nameof(StaticGetCountTestCases))]
    public void StaticGetCountTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, int caseExpectedCount);
    [TestCaseSource(nameof(StaticGetIsReadOnlyTestCases))]
    public void StaticGetIsReadOnlyTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [TestCaseSource(nameof(StaticAddElementsTestCases))]
    public void StaticAddElementsTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticAddPairTestCases))]
    public void StaticAddPairTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticClearTestCases))]
    public void StaticClearTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject);
    [TestCaseSource(nameof(StaticContainsTestCases))]
    public void StaticContainsTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult);
    [TestCaseSource(nameof(StaticContainsKeyTestCases))]
    public void StaticContainsKeyTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult);
    [TestCaseSource(nameof(StaticCopyToTestCases))]
    public void StaticCopyToTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject);
    [TestCaseSource(nameof(StaticPairEnumeratorTestCases))]
    public void StaticPairEnumeratorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator);
    [TestCaseSource(nameof(StaticEnumeratorTestCases))]
    public void StaticEnumeratorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator);
    [TestCaseSource(nameof(StaticRemoveTestCases))]
    public void StaticRemoveTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject);
    [TestCaseSource(nameof(StaticRemovePairTestCases))]
    public void StaticRemovePairTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject);
    [TestCaseSource(nameof(StaticTryGetValueTestCases))]
    public void StaticTryGetValueTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticNullInitializorTestCases))]
    public void StaticNullInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticInterfaceCopyInitializorTestCases))]
    public void StaticInterfaceCopyInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticCopyInitializorTestCases))]
    public void StaticCopyInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializorTestCases))]
    public void StaticDictionaryInterfaceInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticDictionaryInitializorTestCases))]
    public void StaticDictionaryInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticKVPairInitializorTestCases))]
    public void StaticKVPairInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticKVPairArrayInitializorTestCases))]
    public void StaticKVPairArrayInitializorTest(Object caseProvidedObjectInstance, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticElementArraysInitializorTestCases))]
    public void StaticElementArraysInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(StaticValueArrayInitializorTestCases))]
    public void StaticValueArrayInitializorTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
}