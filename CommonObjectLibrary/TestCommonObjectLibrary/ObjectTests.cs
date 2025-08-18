namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using LibraryTestsInterface = IObjectTests;
using Is = NUnit.Framework.Constraints.Is;
using System.Collections;

public class ObjectTests : LibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }
    static readonly TestCaseData[] GetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
    }
    [Test]
    [TestCaseSource(nameof(GetByKeyTestCases))]
    public void GetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.GetByKey(caseProvidedKey), Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] SetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(SetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj[caseProvidedKey] = caseProvidedValue);
        Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
    }
    [Test]
    [TestCaseSource(nameof(SetByKeyTestCases))]
    public void SetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.SetByKey(caseProvidedKey, caseProvidedValue));
        Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] GetKeysTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeysFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysPropertyTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
    {
        Object? obj = null;
        ICollection<string>? keys = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keys = obj.Keys);
        Assert.That(keys, Is.Not.Null);
        Assert.That(keys, Is.InstanceOf<ICollection<string>>());
        Assert.That(keys.Count, Is.EqualTo(caseExpectedKeys.Count));
        Assert.That(caseExpectedKeys, Is.SubsetOf(keys));
        Assert.That(keys, Is.SubsetOf(caseExpectedKeys));
        //TODO: remove the following if the above tests correctly
        //foreach (string key in caseExpectedKeys)
        //{
        //    Assert.That(key, Is.SubsetOf(keys));
        //}
        //foreach (string key in keys)
        //{
        //    Assert.That(key, Is.SubsetOf(caseExpectedKeys));
        //}
    }
    [Test]
    [TestCaseSource(nameof(GetKeysTestCases))]
    public void GetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
    {
        Object? obj = null;
        ICollection<string>? keys = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keys = obj.GetKeys());
        Assert.That(keys, Is.Not.Null);
        Assert.That(keys, Is.InstanceOf<ICollection<string>>());
        Assert.That(keys.Count, Is.EqualTo(caseExpectedKeys.Count));
        Assert.That(caseExpectedKeys, Is.SubsetOf(keys));
        Assert.That(keys, Is.SubsetOf(caseExpectedKeys));
        //TODO: remove the following if the above tests correctly
        //foreach (string key in caseExpectedKeys)
        //{
        //    Assert.That(key, Is.SubsetOf(keys));
        //}
        //foreach (string key in keys)
        //{
        //    Assert.That(key, Is.SubsetOf(caseExpectedKeys));
        //}
    }
    static readonly TestCaseData[] GetValuesTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetValuesFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesPropertyTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
    {
        Object? obj = null;
        ICollection<System.Object>? values = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => values = obj.Values);
        Assert.That(values, Is.Not.Null);
        Assert.That(values, Is.InstanceOf<ICollection<System.Object>>());
        Assert.That(values.Count, Is.EqualTo(caseExpectedValues.Count));
        Assert.That(caseExpectedValues, Is.SubsetOf(values));
        Assert.That(values, Is.SubsetOf(caseExpectedValues));
        //TODO: remove the following if the above tests correctly
        //foreach (string value in caseExpectedValues)
        //{
        //    Assert.That(value, Is.SubsetOf(values));
        //}
        //foreach (string value in values)
        //{
        //    Assert.That(value, Is.SubsetOf(caseExpectedValues));
        //}
    }
    [Test]
    [TestCaseSource(nameof(GetValuesTestCases))]
    public void GetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
    {
        Object? obj = null;
        ICollection<System.Object>? values = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => values = obj.GetValues());
        Assert.That(values, Is.Not.Null);
        Assert.That(values, Is.InstanceOf<ICollection<System.Object>>());
        Assert.That(values.Count, Is.EqualTo(caseExpectedValues.Count));
        Assert.That(caseExpectedValues, Is.SubsetOf(values));
        Assert.That(values, Is.SubsetOf(caseExpectedValues));
        //TODO: remove the following if the above tests correctly
        //foreach (string value in caseExpectedValues)
        //{
        //    Assert.That(value, Is.SubsetOf(values));
        //}
        //foreach (string value in values)
        //{
        //    Assert.That(value, Is.SubsetOf(caseExpectedValues));
        //}
    }
    static readonly TestCaseData[] GetCountTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetCountFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount)
    {
        Object? obj = null;
        int? count = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => count = obj.Count);
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
        Assert.DoesNotThrow(() => count = obj.Keys.Count);
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
    }
    [Test]
    [TestCaseSource(nameof(GetCountTestCases))]
    public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount)
    {
        Object? obj = null;
        int? count = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => count = obj.GetCount());
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
        Assert.DoesNotThrow(() => count = obj.Keys.Count);
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
    }
    static readonly TestCaseData[] GetIsReadOnlyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetIsReadOnlyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
    {
        Object? obj = null;
        bool? isReadOnly = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => isReadOnly = obj.isReadOnly);
        Assert.That(isReadOnly, Is.Not.Null);
        Assert.That(isReadOnly, Is.InstanceOf<bool>());
        Assert.That(isReadOnly, Is.EqualTo(caseExpectedIsReadOnly));
    }
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyTestCases))]
    public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
    {
        Object? obj = null;
        bool? isReadOnly = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => isReadOnly = obj.GetIsReadOnly());
        Assert.That(isReadOnly, Is.Not.Null);
        Assert.That(isReadOnly, Is.InstanceOf<bool>());
        Assert.That(isReadOnly, Is.EqualTo(caseExpectedIsReadOnly));
    }
    static readonly TestCaseData[] AddElementsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(AddElementsTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(AddElementsTestCases))]
    public void AddElementsTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.Add(caseProvidedKey, caseProvidedValue));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseExpectedKey), Is.True);
        Assert.That(obj[caseExpectedKey], Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] AddPairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(AddPairTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(AddPairTestCases))]
    public void AddPairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.Add(caseProvidedPair));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseExpectedKey), Is.True);
        Assert.That(obj[caseExpectedKey], Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] ClearTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ClearTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ClearTestCases))]
    public void ClearTest(System.Object caseProvidedObject)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.Clear());
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.Count, Is.EqualTo(0));
        Assert.That(obj.Keys.Count, Is.EqualTo(0));
        Assert.That(obj.Values.Count, Is.EqualTo(0));
    }
    static readonly TestCaseData[] ContainsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ContainsTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ContainsTestCases))]
    public void ContainsTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
    {
        Object? obj = null;
        bool? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = obj.Contains(caseRequestedValue));
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<bool>());
        Assert.That(result, Is.EqualTo(caseExpectedResult));
    }
    static readonly TestCaseData[] ContainsKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ContainsKeyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ContainsKeyTestCases))]
    public void ContainsKeyTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
    {
        Object? obj = null;
        bool? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = obj.ContainsKey(caseRequestedKey));
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<bool>());
        Assert.That(result, Is.EqualTo(caseExpectedResult));
    }
    static readonly TestCaseData[] CopyToTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyToTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyToTestCases))]
    public void CopyToTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.CopyTo(caseProvidedArray, caseProvidedArrayIndex));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj, Is.EqualTo(caseExpectedObject));
    }
    static readonly TestCaseData[] PairEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(PairEnumeratorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(PairEnumeratorTestCases))]
    public void PairEnumeratorTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
    {
        Object? obj = null;
        IEnumerator<KeyValuePair<string, System.Object>>? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = obj.GetPairEnumerator());
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<IEnumerator<KeyValuePair<string, System.Object>>>());
        Assert.That(result.ToString(), Is.EqualTo(caseExpectedEnumerator.ToString()));
    }
    static readonly TestCaseData[] EnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(EnumeratorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(EnumeratorTestCases))]
    public void EnumeratorTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
    {
        Object? obj = null;
        IEnumerator<KeyValuePair<string, System.Object>>? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = obj.GetPairEnumerator());
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<IEnumerator>());
        Assert.That(result.ToString(), Is.EqualTo(caseExpectedEnumerator.ToString()));
    }
    static readonly TestCaseData[] RemoveTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(RemoveTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(RemoveTestCases))]
    public void RemoveTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.Remove(caseProvidedKey));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseProvidedKey), Is.False);
        Assert.That(obj, Is.EqualTo(caseProvidedObject));
    }
    static readonly TestCaseData[] RemovePairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(RemovePairTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(RemovePairTestCases))]
    public void RemovePairTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.Remove(caseProvidedPair));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseProvidedPair.Key), Is.False);
        Assert.That(obj, Is.EqualTo(caseProvidedObject));
    }
    static readonly TestCaseData[] TryGetValueTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(TryGetValueTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(TryGetValueTestCases))]
    public void TryGetValueTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
    {
        Object? obj = null;
        System.Object? caseResultValue = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.TryGetValue(caseProvidedKey, out caseResultValue));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(caseResultValue, Is.Not.Null);
        Assert.That(caseResultValue, Is.InstanceOf<System.Object>());
        Assert.That(caseResultValue, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] NullInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullInitializerTestCases))]
    public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] InterfaceCopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(InterfaceCopyConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyConstructorTestCases))]
    public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] InterfaceCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(InterfaceCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyInitializerTestCases))]
    public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] CopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] CopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyInitializerTestCases))]
    public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] DictionaryInterfaceConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInterfaceConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceConstructorTestCases))]
    public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] DictionaryInterfaceInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInterfaceInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceInitializerTestCases))]
    public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] DictionaryConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryConstructorTestCases))]
    public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] DictionaryInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInitializerTestCases))]
    public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] KVPairConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairConstructorTestCases))]
    public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] KVPairInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairInitializerTestCases))]
    public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] KVPairArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairArrayConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairArrayConstructorTestCases))]
    public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] KVPairArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairArrayInitializerTestCases))]
    public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] ElementArraysConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ElementArraysConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ElementArraysConstructorTestCases))]
    public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] ElementArraysInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ElementArraysInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ElementArraysInitializerTestCases))]
    public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] ValueArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ValueArrayConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ValueArrayConstructorTestCases))]
    public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] ValueArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ValueArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ValueArrayInitializerTestCases))]
    public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
}
