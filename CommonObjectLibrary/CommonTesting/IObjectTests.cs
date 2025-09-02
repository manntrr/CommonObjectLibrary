using System.Collections;

namespace TestCommonObjectLibrary;

public interface IObjectTests
{
    static readonly TestCaseData[] GetByKeyOperationTestCases = [],
        GetByKeyFunctionTestCases = [],
        SetByKeyOperationTestCases = [],
        SetByKeyFunctionTestCases = [],
        GetKeysPropertyTestCases = [],
        GetKeysFunctionTestCases = [],
        GetValuesPropertyTestCases = [],
        GetValuesFunctionTestCases = [],
        GetCountPropertyTestCases = [],
        GetCountFunctionTestCases = [],
        GetIsReadOnlyPropertyTestCases = [],
        GetIsReadOnlyFunctionTestCases = [],
        GetKeyCaseSensativePropertyTestCases = [],
        GetKeyCaseSensativeFunctionTestCases = [],
        AddElementsFunctionTestCases = [],
        AddPairFunctionTestCases = [],
        ClearFunctionTestCases = [],
        ContainsFunctionTestCases = [],
        ContainsKeyFunctionTestCases = [],
        CopyToFunctionTestCases = [],
        PairEnumeratorFunctionTestCases = [],
        EnumeratorFunctionTestCases = [],
        RemoveFunctionTestCases = [],
        RemovePairFunctionTestCases = [],
        TryGetValueFunctionTestCases = [],
        NullConstructorTestCases = [],
        NullInitializerTestCases = [],
        InterfaceCopyConstructorTestCases = [],
        InterfaceCopyInitializerTestCases = [],
        CopyConstructorTestCases = [],
        CopyInitializerTestCases = [],
        DictionaryInterfaceConstructorTestCases = [],
        DictionaryInterfaceInitializerTestCases = [],
        DictionaryConstructorTestCases = [],
        DictionaryInitializerTestCases = [],
        KVPairConstructorTestCases = [],
        KVPairInitializerTestCases = [],
        KVPairArrayConstructorTestCases = [],
        KVPairArrayInitializerTestCases = [],
        ElementArraysConstructorTestCases = [],
        ElementArraysInitializerTestCases = [],
        ValueArrayConstructorTestCases = [],
        ValueArrayInitializerTestCases = [];
    [SetUp]
    public void Setup();
    [Test]
    [TestCaseSource(nameof(GetByKeyOperationTestCases))]
    public void GetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetByKeyFunctionTestCases))]
    public void GetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(SetByKeyOperationTestCases))]
    public void SetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(SetByKeyFunctionTestCases))]
    public void SetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetKeysPropertyTestCases))]
    public void GetKeysPropertyTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetKeysFunctionTestCases))]
    public void GetKeysFunctionTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetValuesPropertyTestCases))]
    public void GetValuesPropertyTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetValuesFunctionTestCases))]
    public void GetValuesFunctionTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetCountPropertyTestCases))]
    public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetCountFunctionTestCases))]
    public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyPropertyTestCases))]
    public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyFunctionTestCases))]
    public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetKeyCaseSensativePropertyTestCases))]
    public void GetKeyCaseSensativePropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(GetKeyCaseSensativeFunctionTestCases))]
    public void GetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(AddElementsFunctionTestCases))]
    public void AddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(AddPairFunctionTestCases))]
    public void AddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ClearFunctionTestCases))]
    public void ClearFunctionTest(System.Object caseProvidedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ContainsFunctionTestCases))]
    public void ContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ContainsKeyFunctionTestCases))]
    public void ContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(CopyToFunctionTestCases))]
    public void CopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(PairEnumeratorFunctionTestCases))]
    public void PairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(EnumeratorFunctionTestCases))]
    public void EnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(RemoveFunctionTestCases))]
    public void RemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(RemovePairFunctionTestCases))]
    public void RemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(TryGetValueFunctionTestCases))]
    public void TryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(NullInitializerTestCases))]
    public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyConstructorTestCases))]
    public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyInitializerTestCases))]
    public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(CopyInitializerTestCases))]
    public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceConstructorTestCases))]
    public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceInitializerTestCases))]
    public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(DictionaryConstructorTestCases))]
    public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(DictionaryInitializerTestCases))]
    public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(KVPairConstructorTestCases))]
    public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(KVPairInitializerTestCases))]
    public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(KVPairArrayConstructorTestCases))]
    public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(KVPairArrayInitializerTestCases))]
    public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ElementArraysConstructorTestCases))]
    public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ElementArraysInitializerTestCases))]
    public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ValueArrayConstructorTestCases))]
    public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
    [Test]
    [TestCaseSource(nameof(ValueArrayInitializerTestCases))]
    public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException);
}