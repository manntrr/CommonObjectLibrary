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
        StaticNullInitializerTestCases = [],
        StaticInterfaceCopyInitializerTestCases = [],
        StaticCopyInitializerTestCases = [],
        StaticDictionaryInterfaceInitializerTestCases = [],
        StaticDictionaryInitializerTestCases = [],
        StaticKVPairInitializerTestCases = [],
        StaticKVPairArrayInitializerTestCases = [],
        StaticElementArraysInitializerTestCases = [],
        StaticValueArrayInitializerTestCases = [];
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
    [TestCaseSource(nameof(StaticNullInitializerTestCases))]
    public void StaticNullInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticInterfaceCopyInitializerTestCases))]
    public void StaticInterfaceCopyInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticCopyInitializerTestCases))]
    public void StaticCopyInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializerTestCases))]
    public void StaticDictionaryInterfaceInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInitializerTestCases))]
    public void StaticDictionaryInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticKVPairInitializerTestCases))]
    public void StaticKVPairInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticKVPairArrayInitializerTestCases))]
    public void StaticKVPairArrayInitializerTest(Object caseProvidedObjectInstance, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticElementArraysInitializerTestCases))]
    public void StaticElementArraysInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(StaticValueArrayInitializerTestCases))]
    public void StaticValueArrayInitializerTest(Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
}