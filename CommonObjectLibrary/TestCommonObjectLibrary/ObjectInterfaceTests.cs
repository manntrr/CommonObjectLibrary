namespace TestCommonObjectLibrary;

using Object = CommonObjectLibrary.CommonObject;
using ObjectInterface = CommonObjectLibrary.ICommonObject;
using LibraryTestsInterface = IObjectInterfaceTests;
using Is = NUnit.Framework.Constraints.Is;
using System.Collections;
using System.Runtime.InteropServices;

public class ObjectInterfaceTests : LibraryTestsInterface
{
    [SetUp]
    public void Setup()
    {
    }
    static readonly TestCaseData[] StaticGetByKeyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetByKeyFunctionTestCases))]
    public void StaticGetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
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
            Assert.That(ObjectInterface.GET_BY_KEY(obj, caseProvidedKey), Is.EqualTo(caseExpectedValue));
        }
        else
        {
            KeyNotFoundException? exception = Assert.Throws<KeyNotFoundException>(() => value = ObjectInterface.GET_BY_KEY(obj, caseProvidedKey));
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] StaticSetByKeyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticSetByKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticSetByKeyFunctionTestCases))]
    public void StaticSetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        if (caseExpectedException is null)
        {
            Assert.DoesNotThrow(() => ObjectInterface.SET_BY_KEY(obj, caseProvidedKey, caseProvidedValue));
            Assert.That(obj[caseProvidedKey], Is.EqualTo(caseExpectedValue));
        }
        else
        {
            InvalidOperationException? exception = Assert.Throws<InvalidOperationException>(() => ObjectInterface.SET_BY_KEY(obj, caseProvidedKey, caseProvidedValue));
            Assert.That(exception.GetType(), Is.EqualTo(caseExpectedException.GetType()));
            Assert.That(exception.Message, Is.EqualTo(caseExpectedException.Message));
        }
    }
    static readonly TestCaseData[] StaticGetKeysFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetKeysFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetKeysFunctionTestCases))]
    public void StaticGetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys, Exception caseExpectedException)
    {
        Object? obj = null;
        ICollection<string>? keys = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keys = ObjectInterface.GET_KEYS(obj));
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
    static readonly TestCaseData[] StaticGetValuesFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetValuesFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetValuesFunctionTestCases))]
    public void StaticGetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues, Exception caseExpectedException)
    {
        Object? obj = null;
        ICollection<System.Object>? values = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => values = ObjectInterface.GET_VALUES(obj));
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
    static readonly TestCaseData[] StaticGetCountFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetCountFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetCountFunctionTestCases))]
    public void StaticGetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount, Exception caseExpectedException)
    {
        Object? obj = null;
        int? count = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => count = ObjectInterface.GET_COUNT(obj));
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
        Assert.DoesNotThrow(() => count = obj.Keys.Count);
        Assert.That(count, Is.Not.Null);
        Assert.That(count, Is.InstanceOf<int>());
        Assert.That(count, Is.EqualTo(caseExpectedCount));
    }
    static readonly TestCaseData[] StaticGetIsReadOnlyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetIsReadOnlyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetIsReadOnlyFunctionTestCases))]
    public void StaticGetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? isReadOnly = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => isReadOnly = ObjectInterface.GET_IS_READ_ONLY(obj));
        Assert.That(isReadOnly, Is.Not.Null);
        Assert.That(isReadOnly, Is.InstanceOf<bool>());
        Assert.That(isReadOnly, Is.EqualTo(caseExpectedIsReadOnly));
    }
    static readonly TestCaseData[] StaticGetKeyCaseSensativeFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetKeyCaseSensativeFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticGetKeyCaseSensativeFunctionTestCases))]
    public void StaticGetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? keyCaseSensative = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => keyCaseSensative = ObjectInterface.GET_KEY_CASE_SENSATIVE(obj));
        Assert.That(keyCaseSensative, Is.Not.Null);
        Assert.That(keyCaseSensative, Is.InstanceOf<bool>());
        Assert.That(keyCaseSensative, Is.EqualTo(caseExpectedKeyCaseSensative));
    }
    static readonly TestCaseData[] StaticAddElementsFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddElementsFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticAddElementsFunctionTestCases))]
    public void StaticAddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.ADD(obj, caseProvidedKey, caseProvidedValue));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseExpectedKey), Is.True);
        Assert.That(obj[caseExpectedKey], Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticAddPairFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddPairFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticAddPairFunctionTestCases))]
    public void StaticAddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.ADD(obj, caseProvidedPair));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseExpectedKey), Is.True);
        Assert.That(obj[caseExpectedKey], Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticClearFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticClearFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticClearFunctionTestCases))]
    public void StaticClearFunctionTest(System.Object caseProvidedObject, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.CLEAR(obj));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.Count, Is.EqualTo(0));
        Assert.That(obj.Keys.Count, Is.EqualTo(0));
        Assert.That(obj.Values.Count, Is.EqualTo(0));
    }
    static readonly TestCaseData[] StaticContainsFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticContainsFunctionTestCases))]
    public void StaticContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = ObjectInterface.CONTAINS(obj, caseRequestedValue));
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<bool>());
        Assert.That(result, Is.EqualTo(caseExpectedResult));
    }
    static readonly TestCaseData[] StaticContainsKeyFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsKeyFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticContainsKeyFunctionTestCases))]
    public void StaticContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = ObjectInterface.CONTAINS_KEY(obj, caseRequestedKey));
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<bool>());
        Assert.That(result, Is.EqualTo(caseExpectedResult));
    }
    static readonly TestCaseData[] StaticCopyToFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyToFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticCopyToFunctionTestCases))]
    public void StaticCopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.COPY_TO(obj, caseProvidedArray, caseProvidedArrayIndex));
        Assert.That(caseProvidedArray, Is.Not.Null);
        Assert.That(caseProvidedArray, Is.InstanceOf<KeyValuePair<string, System.Object>[]>());
        Assert.That(caseProvidedArray.Length, Is.EqualTo(caseExpectedArray.Length));
        for (int index = 0; index < caseExpectedArray.Length; index++)
        {
            Assert.That(caseProvidedArray[index].Key, Is.EqualTo(caseExpectedArray[index].Key));
            Assert.That(caseProvidedArray[index].Value, Is.EqualTo(caseExpectedArray[index].Value));
        }
    }
    static readonly TestCaseData[] StaticPairEnumeratorFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticPairEnumeratorFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticPairEnumeratorFunctionTestCases))]
    public void StaticPairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator, Exception caseExpectedException)
    {
        string resultString = "", expectedString = "";
        Object? obj = null;
        IEnumerator<KeyValuePair<string, System.Object>>? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = ObjectInterface.GET_PAIR_ENUMERATOR(obj));
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
    static readonly TestCaseData[] StaticEnumeratorFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticEnumeratorFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticEnumeratorFunctionTestCases))]
    public void StaticEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator, Exception caseExpectedException)
    {
        string resultString = "", expectedString = "";
        Object? obj = null;
        IEnumerator<KeyValuePair<string, System.Object>>? result = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => result = (IEnumerator<KeyValuePair<string, object>>?)ObjectInterface.GET_ENUMERATOR(obj));
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
    static readonly TestCaseData[] StaticRemoveFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemoveFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticRemoveFunctionTestCases))]
    public void StaticRemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.REMOVE(obj, caseProvidedKey));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseProvidedKey), Is.False);
        Assert.That(obj, Is.EqualTo(caseProvidedObject));
    }
    static readonly TestCaseData[] StaticRemovePairFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemovePairFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticRemovePairFunctionTestCases))]
    public void StaticRemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject, Exception caseExpectedException)
    {
        Object? obj = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => ObjectInterface.REMOVE(obj, caseProvidedPair));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(obj.ContainsKey(caseProvidedPair.Key), Is.False);
        Assert.That(obj, Is.EqualTo(caseProvidedObject));
    }
    static readonly TestCaseData[] StaticTryGetValueFunctionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticTryGetValueFunctionTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticTryGetValueFunctionTestCases))]
    public void StaticTryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        Object? obj = null;
        bool? caseResult = null;
        System.Object? caseResultValue = null;
        Assert.That(caseProvidedObject, Is.Not.Null);
        Assert.That(caseProvidedObject, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => obj = (Object)caseProvidedObject);
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.DoesNotThrow(() => caseResult = ObjectInterface.TRY_GET_VALUE(obj, caseProvidedKey, out caseResultValue));
        Assert.That(obj, Is.Not.Null);
        Assert.That(obj, Is.InstanceOf<Object>());
        Assert.That(caseResultValue, Is.Not.Null);
        Assert.That(caseResultValue, Is.InstanceOf<System.Object>());
        Assert.That(caseResult, Is.Not.Null);
        Assert.That(caseResult, Is.EqualTo(caseExpectedResult));
        Assert.That(caseResultValue.ToString(), Is.EqualTo(caseExpectedValue.ToString()));
    }
    static readonly TestCaseData[] StaticNullInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticNullInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticNullInitializerTestCases))]
    public void StaticNullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedObject);
        Assert.That((ObjectInterface)caseProvidedObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticInterfaceCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticInterfaceCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticInterfaceCopyInitializerTestCases))]
    public void StaticInterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, interfaceObject: (ObjectInterface)caseProvidedObject);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticCopyInitializerTestCases))]
    public void StaticCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, obj: (Object)caseProvidedObject);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticDictionaryInterfaceInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInterfaceInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInterfaceInitializerTestCases))]
    public void StaticDictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, dictionaryInterface: caseProvidedDictionaryInterface);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticDictionaryInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticDictionaryInitializerTestCases))]
    public void StaticDictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, dictionary: caseProvidedDictionary);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticKVPairInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticKVPairInitializerTestCases))]
    public void StaticKVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, keyValuePair: caseProvidedKVPair);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticKVPairArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticKVPairArrayInitializerTestCases))]
    public void StaticKVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, keyValuePairArray: caseProvidedKVPairArray);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticElementArraysInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticElementArraysInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticElementArraysInitializerTestCases))]
    public void StaticElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, keys: caseProvidedKeyArray, values: caseProvidedValueArray);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
    static readonly TestCaseData[] StaticValueArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticValueArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(StaticValueArrayInitializerTestCases))]
    public void StaticValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue, Exception caseExpectedException)
    {
        ObjectInterface.INIT((Object)caseProvidedInitialObject, values: caseProvidedValueArray);
        Assert.That((ObjectInterface)caseProvidedInitialObject, Is.EqualTo((ObjectInterface)caseExpectedValue));
        Assert.That(caseProvidedInitialObject, Is.EqualTo(caseExpectedValue));
    }
}