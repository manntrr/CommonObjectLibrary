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
    static readonly TestCaseData[] GetByKeyOperationTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetByKeyOperationTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetByKeyOperationTestCases))]
    public void GetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        System.Object value;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        if (caseExpectedException is null)
        {
            Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
        }
        else
        {
            KeyNotFoundException? exception = Assert.Throws<KeyNotFoundException>(() => value = obj[caseProvidedKey]);
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] GetByKeyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetByKeyFunctionTestCases))]
    public void GetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        System.Object value;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        if (caseExpectedException is null)
        {
            Assert.That(obj.GetByKey(caseProvidedKey), Is.EqualTo(caseExpectedValue));
        }
        else
        {
            KeyNotFoundException? exception = Assert.Throws<KeyNotFoundException>(() => value = obj.GetByKey(caseProvidedKey));
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] SetByKeyOperationTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(SetByKeyOperationTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(SetByKeyOperationTestCases))]
    public void SetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        if (caseExpectedException is null)
        {
            Assert.DoesNotThrow(() => obj[caseProvidedKey] = caseProvidedValue);
            Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
        }
        else
        {
            InvalidOperationException? exception = Assert.Throws<InvalidOperationException>(() => obj[caseProvidedKey] = caseProvidedValue);
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] SetByKeyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(SetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(SetByKeyFunctionTestCases))]
    public void SetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        if (caseExpectedException is null)
        {
            Assert.DoesNotThrow(() => obj.SetByKey(caseProvidedKey, caseProvidedValue));
            Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
        }
        else
        {
            InvalidOperationException? exception = Assert.Throws<InvalidOperationException>(() => obj.SetByKey(caseProvidedKey, caseProvidedValue));
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] GetKeysPropertyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeysPropertyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeysPropertyTestCases))]
    public void GetKeysPropertyTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetKeysFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeysFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeysFunctionTestCases))]
    public void GetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetValuesPropertyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetValuesPropertyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetValuesPropertyTestCases))]
    public void GetValuesPropertyTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetValuesFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetValuesFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetValuesFunctionTestCases))]
    public void GetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetCountPropertyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetCountPropertyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetCountPropertyTestCases))]
    public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetCountFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetCountFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetCountFunctionTestCases))]
    public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetIsReadOnlyPropertyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetIsReadOnlyPropertyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyPropertyTestCases))]
    public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetIsReadOnlyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetIsReadOnlyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetIsReadOnlyFunctionTestCases))]
    public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException)
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
    static readonly TestCaseData[] GetKeyCaseSensativePropertyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeyCaseSensativePropertyTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeyCaseSensativePropertyTestCases))]
    public void GetKeyCaseSensativePropertyTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? keyCaseSensative = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keyCaseSensative = obj.KeyCaseSensative);
        Assert.That(keyCaseSensative, Is.Not.Null);
        Assert.That(keyCaseSensative, Is.InstanceOf<bool>());
        Assert.That(keyCaseSensative, Is.EqualTo(caseExpectedKeyCaseSensative));
    }
    static readonly TestCaseData[] GetKeyCaseSensativeFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeyCaseSensativeFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeyCaseSensativeFunctionTestCases))]
    public void GetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? keyCaseSensative = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keyCaseSensative = obj.GetKeyCaseSensative());
        Assert.That(keyCaseSensative, Is.Not.Null);
        Assert.That(keyCaseSensative, Is.InstanceOf<bool>());
        Assert.That(keyCaseSensative, Is.EqualTo(caseExpectedKeyCaseSensative));
    }
    static readonly TestCaseData[] AddElementsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(AddElementsFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(AddElementsTestCases))]
    public void AddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException)
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
    static readonly TestCaseData[] AddPairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(AddPairFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(AddPairTestCases))]
    public void AddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException)
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
    static readonly TestCaseData[] ClearTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ClearFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ClearTestCases))]
    public void ClearFunctionTest(System.Object caseProvidedObject, Exception caseExpectedException)
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
    static readonly TestCaseData[] ContainsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ContainsFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ContainsTestCases))]
    public void ContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult, Exception caseExpectedException)
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
    static readonly TestCaseData[] ContainsKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ContainsKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ContainsKeyTestCases))]
    public void ContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult, Exception caseExpectedException)
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
    static readonly TestCaseData[] CopyToTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyToFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyToTestCases))]
    public void CopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj.CopyTo(caseProvidedArray, caseProvidedArrayIndex));
        Assert.That(caseProvidedArray, Is.Not.Null);
        Assert.That(caseProvidedArray, Is.InstanceOf<KeyValuePair<string, System.Object>[]>());
        Assert.That(caseProvidedArray.Length, Is.EqualTo(caseExpectedArray.Length));
        for (int index = 0; index < caseExpectedArray.Length; index++)
        {
            Assert.That(caseProvidedArray[index].Key, Is.EqualTo(caseExpectedArray[index].Key));
            Assert.That(caseProvidedArray[index].Value, Is.EqualTo(caseExpectedArray[index].Value));
        }
    }
    static readonly TestCaseData[] PairEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(PairEnumeratorFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(PairEnumeratorTestCases))]
    public void PairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator, Exception caseExpectedException)
    {
        string resultString = "", expectedString = "";
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
        while (result.MoveNext())
        {
            resultString += "{" + result.Current.Key + " , " + result.Current.Value.ToString() + "}";
        }
        while (caseExpectedEnumerator.MoveNext())
        {
            expectedString += "{" + caseExpectedEnumerator.Current.Key + " , " + caseExpectedEnumerator.Current.Value.ToString() + "}";
        }
        Assert.That(resultString, Is.EqualTo(expectedString));
    }
    static readonly TestCaseData[] EnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(EnumeratorFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(EnumeratorTestCases))]
    public void EnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator, Exception caseExpectedException)
    {
        string resultString = "", expectedString = "";
        Object? obj = null;
        IEnumerator<KeyValuePair<string, System.Object>>? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = (IEnumerator<KeyValuePair<string, object>>?)obj.GetEnumerator());
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<IEnumerator>());
        while (result.MoveNext())
        {
            resultString += "{" + result.Current.Key + " , " + result.Current.Value.ToString() + "}";
        }
        while (caseExpectedEnumerator.MoveNext())
        {
            expectedString += "{" + ((KeyValuePair<string, System.Object>)caseExpectedEnumerator.Current).Key + " , " + ((KeyValuePair<string, System.Object>)caseExpectedEnumerator.Current).Value.ToString() + "}";
        }
        Assert.That(resultString, Is.EqualTo(expectedString));
    }
    static readonly TestCaseData[] RemoveTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(RemoveFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(RemoveTestCases))]
    public void RemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject, Exception caseExpectedException)
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
    static readonly TestCaseData[] RemovePairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(RemovePairFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(RemovePairTestCases))]
    public void RemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject, Exception caseExpectedException)
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
    static readonly TestCaseData[] TryGetValueTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(TryGetValueFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(TryGetValueTestCases))]
    public void TryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? caseResult = null;
        System.Object? caseResultValue = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => caseResult = obj.TryGetValue(caseProvidedKey, out caseResultValue));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(caseResultValue, Is.Not.Null);
        Assert.That(caseResultValue, Is.InstanceOf<System.Object>());
        Assert.That(caseResult, Is.Not.Null);
        Assert.That(caseResult, Is.EqualTo(caseExpectedResult));
        Assert.That(caseResultValue.ToString(), Is.EqualTo(caseExpectedValue.ToString()));
    }
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] NullInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullInitializerTestCases))]
    public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedObject;
        obj.Init();
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        Assert.That(obj, Is.EqualTo(obj));
    }
    static readonly TestCaseData[] InterfaceCopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(InterfaceCopyConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyConstructorTestCases))]
    public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(interfaceObject: (ObjectInterface)caseProvidedObject);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] InterfaceCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(InterfaceCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(InterfaceCopyInitializerTestCases))]
    public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(interfaceObject: (ObjectInterface)caseProvidedObject);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] CopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(obj: (Object)caseProvidedObject);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] CopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyInitializerTestCases))]
    public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(obj: (Object)caseProvidedObject);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] DictionaryInterfaceConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInterfaceConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceConstructorTestCases))]
    public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(dictionaryInterface: caseProvidedDictionaryInterface);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] DictionaryInterfaceInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInterfaceInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInterfaceInitializerTestCases))]
    public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(dictionaryInterface: caseProvidedDictionaryInterface);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] DictionaryConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryConstructorTestCases))]
    public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(dictionary: caseProvidedDictionary);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] DictionaryInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DictionaryInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DictionaryInitializerTestCases))]
    public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(dictionary: caseProvidedDictionary);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] KVPairConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairConstructorTestCases))]
    public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(keyValuePair: caseProvidedKVPair);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] KVPairInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairInitializerTestCases))]
    public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(keyValuePair: caseProvidedKVPair);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] KVPairArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairArrayConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairArrayConstructorTestCases))]
    public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(keyValuePairArray: caseProvidedKVPairArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] KVPairArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KVPairArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KVPairArrayInitializerTestCases))]
    public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(keyValuePairArray: caseProvidedKVPairArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] ElementArraysConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ElementArraysConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ElementArraysConstructorTestCases))]
    public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(keys: caseProvidedKeyArray, values: caseProvidedValueArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] ElementArraysInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ElementArraysInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ElementArraysInitializerTestCases))]
    public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(keys: caseProvidedKeyArray, values: caseProvidedValueArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] ValueArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ValueArrayConstructorTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ValueArrayConstructorTestCases))]
    public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = new(values: caseProvidedValueArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] ValueArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(ValueArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(ValueArrayInitializerTestCases))]
    public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object obj = (Object)caseProvidedInitialObject;
        obj.Init(values: caseProvidedValueArray);
        Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(obj, Is.EqualTo(caseExpectedValue));
    }
}