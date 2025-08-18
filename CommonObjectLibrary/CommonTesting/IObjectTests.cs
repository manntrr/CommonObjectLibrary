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
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyOperationTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyFunctionTest(Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysPropertyTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [Test]
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysFunctionTest(Object caseProvidedObject, ICollection<string> caseExpectedKeys);
    [Test]
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesPropertyTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [Test]
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesFunctionTest(Object caseProvidedObject, ICollection<System.Object> caseExpectedValues);
    [Test]
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount);
    [Test]
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly);
    [Test]
    [TestCaseSource(nameof(AddElementsTestCases))]
    public void AddElementsTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(AddPairTestCases))]
    public void AddPairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(ClearTestCases))]
    public void ClearTest(System.Object caseProvidedObject);
    [Test]
    [TestCaseSource(nameof(ContainsTestCases))]
    public void ContainsTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult);
    [Test]
    [TestCaseSource(nameof(ContainsKeyTestCases))]
    public void ContainsKeyTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult);
    [Test]
    [TestCaseSource(nameof(CopyToTestCases))]
    public void CopyToTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(PairEnumeratorTestCases))]
    public void PairEnumeratorTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator);
    [Test]
    [TestCaseSource(nameof(EnumeratorTestCases))]
    public void EnumeratorTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator);
    [Test]
    [TestCaseSource(nameof(RemoveTestCases))]
    public void RemoveTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(RemovePairTestCases))]
    public void RemovePairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject);
    [Test]
    [TestCaseSource(nameof(TryGetValueTestCases))]
    public void TryGetValueTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(NullInitializerTestCases))]
    public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyConstructorTestCases))]
    public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyInitializerTestCases))]
    public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(CopyInitializerTestCases))]
    public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceConstructorTestCases))]
    public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceInitializerTestCases))]
    public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(DictionaryConstructorTestCases))]
    public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(DictionaryInitializerTestCases))]
    public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(KVPairConstructorTestCases))]
    public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(KVPairInitializerTestCases))]
    public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(KVPairArrayConstructorTestCases))]
    public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(KVPairArrayInitializerTestCases))]
    public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(ElementArraysConstructorTestCases))]
    public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(ElementArraysInitializerTestCases))]
    public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(ValueArrayConstructorTestCases))]
    public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
    [Test]
    [TestCaseSource(nameof(ValueArrayInitializerTestCases))]
    public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue);
}