using System.Collections;

namespace TestCommonObjectLibrary;

public interface IObjectTests
{
    static readonly TestCaseData[] GetByKeyTestCases = [],
        SetByKeyTestCases = [],
        GetKeysTestCases = [],
        GetValuesTestCases = [],
        GetCountTestCases = [],
        GetIsReadOnlyTestCases = [],
        AddElementsTestCases = [],
        AddPairTestCases = [],
        ClearTestCases = [],
        ContainsTestCases = [],
        ContainsKeyTestCases = [],
        CopyToTestCases = [],
        PairEnumeratorTestCases = [],
        EnumeratorTestCases = [],
        RemoveTestCases = [],
        RemovePairTestCases = [],
        TryGetValueTestCases = [],
        NullConstructorTestCases = [],
        NullInitializorTestCases = [],
        InterfaceCopyConstructorTestCases = [],
        InterfaceCopyInitializorTestCases = [],
        CopyConstructorTestCases = [],
        CopyInitializorTestCases = [],
        DictionaryInterfaceConstructorTestCases = [],
        DictionaryInterfaceInitializorTestCases = [],
        DictionaryConstructorTestCases = [],
        DictionaryInitializorTestCases = [],
        KVPairConstructorTestCases = [],
        KVPairInitializorTestCases = [],
        KVPairArrayConstructorTestCases = [],
        KVPairArrayInitializorTestCases = [],
        ElementArraysConstructorTestCases = [],
        ElementArraysInitializorTestCases = [],
        ValueArrayConstructorTestCases = [],
        ValueArrayInitializorTestCases = [];
    [SetUp]
    public void Setup();
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysPropertyTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysFunctionTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesPropertyTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesFunctionTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount);
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount);
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [TestCaseSource(nameof(AddElementsTestCases))]
    public void AddElementsTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(AddPairTestCases))]
    public void AddPairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(ClearTestCases))]
    public void ClearTest(System.Object caseProvidedObject);
    [TestCaseSource(nameof(ContainsTestCases))]
    public void ContainsTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult);
    [TestCaseSource(nameof(ContainsKeyTestCases))]
    public void ContainsKeyTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult);
    [TestCaseSource(nameof(CopyToTestCases))]
    public void CopyToTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject);
    [TestCaseSource(nameof(PairEnumeratorTestCases))]
    public void PairEnumeratorTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator);
    [TestCaseSource(nameof(EnumeratorTestCases))]
    public void EnumeratorTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator);
    [TestCaseSource(nameof(RemoveTestCases))]
    public void RemoveTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject);
    [TestCaseSource(nameof(RemovePairTestCases))]
    public void RemovePairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject);
    [TestCaseSource(nameof(TryGetValueTestCases))]
    public void TryGetValueTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(System.Object caseExpectedValue);
    [TestCaseSource(nameof(NullInitializorTestCases))]
    public void NullInitializorTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(InterfaceCopyConstructorTestCases))]
    public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(InterfaceCopyInitializorTestCases))]
    public void InterfaceCopyInitializorTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(CopyInitializorTestCases))]
    public void CopyInitializorTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [TestCaseSource(nameof(DictionaryInterfaceConstructorTestCases))]
    public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [TestCaseSource(nameof(DictionaryInterfaceInitializorTestCases))]
    public void DictionaryInterfaceInitializorTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [TestCaseSource(nameof(DictionaryConstructorTestCases))]
    public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [TestCaseSource(nameof(DictionaryInitializorTestCases))]
    public void DictionaryInitializorTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [TestCaseSource(nameof(KVPairConstructorTestCases))]
    public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [TestCaseSource(nameof(KVPairInitializorTestCases))]
    public void KVPairInitializorTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [TestCaseSource(nameof(KVPairArrayConstructorTestCases))]
    public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(KVPairArrayInitializorTestCases))]
    public void KVPairArrayInitializorTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(ElementArraysConstructorTestCases))]
    public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(ElementArraysInitializorTestCases))]
    public void ElementArraysInitializorTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(ValueArrayConstructorTestCases))]
    public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [TestCaseSource(nameof(ValueArrayInitializorTestCases))]
    public void ValueArrayInitializorTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
}