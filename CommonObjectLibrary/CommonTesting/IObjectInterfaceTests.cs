using System.Collections;

namespace TestCommonObjectLibrary;

public interface IObjectInterfaceTests
{
    static readonly TestCaseData[] StaticGetByKeyFunctionTestCases = [],
        StaticSetByKeyFunctionTestCases = [],
        StaticGetKeysFunctionTestCases = [],
        StaticGetValuesFunctionTestCases = [],
        StaticGetCountFunctionTestCases = [],
        StaticGetIsReadOnlyFunctionTestCases = [],
        StaticGetKeyCaseSensativeFunctionTestCases = [],
        StaticAddElementsFunctionTestCases = [],
        StaticAddPairFunctionTestCases = [],
        StaticClearFunctionTestCases = [],
        StaticContainsFunctionTestCases = [],
        StaticContainsKeyFunctionTestCases = [],
        StaticCopyToFunctionTestCases = [],
        StaticPairEnumeratorFunctionTestCases = [],
        StaticEnumeratorFunctionTestCases = [],
        StaticRemoveFunctionTestCases = [],
        StaticRemovePairFunctionTestCases = [],
        StaticTryGetValueFunctionTestCases = [],
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
    [TestCaseSource(nameof(StaticGetByKeyFunctionTestCases))]
    public void StaticGetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticSetByKeyFunctionTestCases))]
    public void StaticSetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticGetKeysFunctionTestCases))]
    public void StaticGetKeysFunctionTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticGetValuesFunctionTestCases))]
    public void StaticGetValuesFunctionTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticGetCountFunctionTestCases))]
    public void StaticGetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticGetIsReadOnlyFunctionTestCases))]
    public void StaticGetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticGetKeyCaseSensativeFunctionTestCases))]
    public void StaticGetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticAddElementsFunctionTestCases))]
    public void StaticAddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticAddPairFunctionTestCases))]
    public void StaticAddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticClearFunctionTestCases))]
    public void StaticClearFunctionTest(System.Object caseProvidedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticContainsFunctionTestCases))]
    public void StaticContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticContainsKeyFunctionTestCases))]
    public void StaticContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticCopyToFunctionTestCases))]
    public void StaticCopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticPairEnumeratorFunctionTestCases))]
    public void StaticPairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticEnumeratorFunctionTestCases))]
    public void StaticEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticRemoveFunctionTestCases))]
    public void StaticRemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticRemovePairFunctionTestCases))]
    public void StaticRemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticTryGetValueFunctionTestCases))]
    public void StaticTryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticNullInitializerTestCases))]
    public void StaticNullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticInterfaceCopyInitializerTestCases))]
    public void StaticInterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticCopyInitializerTestCases))]
    public void StaticCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializerTestCases))]
    public void StaticDictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInitializerTestCases))]
    public void StaticDictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticKVPairInitializerTestCases))]
    public void StaticKVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticKVPairArrayInitializerTestCases))]
    public void StaticKVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticElementArraysInitializerTestCases))]
    public void StaticElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(StaticValueArrayInitializerTestCases))]
    public void StaticValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
}