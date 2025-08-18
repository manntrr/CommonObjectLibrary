namespace CommonObjectLibrary;

using System.Collections;

using Object = CommonObject;
using ObjectInterface = ICommonObject;
using TCDD = /*NUnit.Framework./**/TestCaseDataDictionary;
using TCsDD = /*NUnit.Framework./**/TestCasesDataDictionary;
using COLTs = TestCommonObjectLibrary.ILibraryTests;
using InvalidArgumentException = NUnit.Framework.InvalidArgumentException;


public interface ICommonObject : IDictionary<string, System.Object>
{
    private static int counter = 0;
    bool isReadOnly { get; set; }
    ICollection<string> BaseKeys { get; }
    ICollection<System.Object> BaseValues { get; }
    int BaseCount { get; }
    void BaseAdd(string key, System.Object value);
    void BaseAdd(KeyValuePair<string, System.Object> item);
    void BaseClear();
    bool BaseContains(KeyValuePair<string, System.Object> item);
    bool BaseContainsKey(string key);
    void BaseCopyTo(KeyValuePair<string, System.Object>[] array, int arrayIndex);
    IEnumerator<KeyValuePair<string, System.Object>> BaseGetPairEnumerator();
    IEnumerator BaseGetEnumerator();
    bool BaseRemove(string key);
    bool BaseRemove(KeyValuePair<string, System.Object> item);
    bool BaseTryGetValue(string key, out System.Object value);
    public System.Object GetByKey(string key);
    public void SetByKey(string key, System.Object value);
    public ICollection<string> GetKeys();
    public ICollection<System.Object> GetValues();
    public int GetCount();
    public bool GetIsReadOnly();
    new public void Add(string key, System.Object value);
    new public void Add(KeyValuePair<string, System.Object> item);
    new public void Clear();
    new public bool Contains(KeyValuePair<string, System.Object> item);
    new public bool ContainsKey(string key);
    new public void CopyTo(KeyValuePair<string, System.Object>[] array, int arrayIndex);
    public IEnumerator<KeyValuePair<string, System.Object>> GetPairEnumerator();
    new public IEnumerator GetEnumerator();
    new public bool Remove(string key);
    new public bool Remove(KeyValuePair<string, System.Object> item);
    new public bool TryGetValue(string key, out System.Object value);
    public void Init();
    public void Init(ObjectInterface originalObject);
    public void Init(Object originalObject);
    public void Init(IDictionary<string, System.Object> originalObject);
    public void Init(Dictionary<string, System.Object> originalObject);
    public void Init(KeyValuePair<string, System.Object> originalObject);
    public void Init(KeyValuePair<string, System.Object>[] objects);
    public void Init(string[] keys, System.Object[] objects);
    public void Init(System.Object[] objects);

    /*
        public static System.Object GET_BY_KEY(ObjectInterface _object, string key)
        {
            return _object[key];
        }
    /**/
    /*
        public static void SET_BY_KEY(ObjectInterface _object, string key, System.Object value)
        {
            _object[key] = value;
        }
    /**/
    public static ICollection<string> GET_KEYS(ObjectInterface _object)
    {
        return _object.BaseKeys;
    }
    public static ICollection<System.Object> GET_VALUES(ObjectInterface _object)
    {
        return (ICollection<System.Object>)_object.BaseValues;
    }
    public static int GET_COUNT(ObjectInterface _object)
    {
        return _object.BaseCount;
    }
    public static bool GET_IS_READ_ONLY(ObjectInterface _object)
    {
        return _object.isReadOnly;
    }
    public static void ADD(ObjectInterface _object, string key, System.Object value)
    {
        _object.BaseAdd(key, (System.Object)value);
    }
    public static void ADD(ObjectInterface _object, KeyValuePair<string, System.Object> item)
    {
        _object.BaseAdd(new KeyValuePair<string, System.Object>(key: item.Key, value: (System.Object)item.Value));
    }
    public static void CLEAR(ObjectInterface _object)
    {
        _object.BaseClear();
    }
    public static bool CONTAINS(ObjectInterface _object, KeyValuePair<string, System.Object> item)
    {
        return _object.BaseContains(new KeyValuePair<string, System.Object>(key: item.Key, value: (System.Object)item.Value));
    }
    public static bool CONTAINS_KEY(ObjectInterface _object, string key)
    {
        return _object.BaseContainsKey(key);
    }
    public static void COPY_TO(ObjectInterface _object, KeyValuePair<string, System.Object>[] array, int arrayIndex)
    {
        KeyValuePair<string, System.Object>[] temp = new KeyValuePair<string, System.Object>[array.Length];
        for (int i = 0; i < array.Length; i++) temp[i] = new(array[i].Key, (System.Object)array[i].Value);
        _object.BaseCopyTo(temp, arrayIndex);
    }
    public static IEnumerator<KeyValuePair<string, System.Object>> GET_PAIR_ENUMERATOR(ObjectInterface _object)
    {
        IEnumerator<KeyValuePair<string, System.Object>> temp = _object.BaseGetPairEnumerator();
        List<KeyValuePair<string, System.Object>> result = [];
        while (temp.MoveNext())
            result.Add(new(temp.Current.Key, temp.Current.Value));
        return result.GetEnumerator();
    }
    public static IEnumerator GET_ENUMERATOR(ObjectInterface _object)
    {
        return _object.BaseGetEnumerator();
    }
    public static bool REMOVE(ObjectInterface _object, string key)
    {
        return _object.BaseRemove(key);
    }
    public static bool REMOVE(ObjectInterface _object, KeyValuePair<string, System.Object> item)
    {
        return _object.BaseRemove(new KeyValuePair<string, System.Object>(key: item.Key, value: (System.Object)item.Value));
    }
    public static bool TRY_GET_VALUE(ObjectInterface _object, string key, out System.Object value)
    {
        System.Object temp;
        bool result = _object.BaseTryGetValue(key, out temp);
        value = temp;
        return result;
    }
    public static void INIT(ObjectInterface newObject)
    {
        var keyList = GET_KEYS(newObject);
        foreach (string key in keyList)
        {
            REMOVE(newObject, key: key);
        }
    }
    public static void INIT(ObjectInterface newObject, ObjectInterface originalObject)
    {
        INIT(newObject);
        foreach (KeyValuePair<string, System.Object> pair in originalObject)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
    }
    public static void INIT(ObjectInterface newObject, Object originalObject)
    {
        INIT(newObject);
        foreach (KeyValuePair<string, System.Object> pair in originalObject)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
    }
    public static void INIT(ObjectInterface newObject, IDictionary<string, System.Object> originalObject)
    {
        INIT(newObject);
        foreach (KeyValuePair<string, System.Object> pair in originalObject)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
    }
    public static void INIT(ObjectInterface newObject, Dictionary<string, System.Object> originalObject)
    {
        INIT(newObject);
        foreach (KeyValuePair<string, System.Object> pair in originalObject)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object> originalObject)
    {
        INIT(newObject);
        ADD(newObject, key: originalObject.Key, value: originalObject.Value);
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object>[] objects)
    {
        INIT(newObject);
        foreach (KeyValuePair<string, System.Object> pair in objects)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
    }
    public static void INIT(ObjectInterface newObject, string[] keys, System.Object[] objects)
    {
        if (keys.Length != objects.Length) throw new InvalidArgumentException();
        INIT(newObject);
        for (int index = 0; index < keys.Length; index++)
        {
            ADD(newObject, key: keys[index], value: objects[index]);
        }
    }
    public static void INIT(ObjectInterface newObject, System.Object[] objects)
    {
        INIT(newObject);
        for (int index = 0; index < objects.Length; index++)
        {
            ADD(newObject, key: objects[index].ToString() ?? "", value: objects[index]);
        }
    }
    static readonly TCsDD TEST_CASE_DATA = new([
        // TODO:  complete test case data
        /**/new(nameof(COLTs.GetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        //        public void GetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        //        public void GetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test", "test") }), "test", "test"
                )
        ])),
        new(nameof(COLTs.SetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        //        public void SetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        //        public void SetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(), "test", "test", "test"
                )
        ])),
        new(nameof(COLTs.GetKeysFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        //        public void GetKeysPropertyTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        //        public void GetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(), new[] {"test"}
                )
        ]))/**/
        /*
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
                foreach (string value in caseExpectedValues)
                {
                    Assert.That(value, Is.SubsetOf(values));
                }
                foreach (string value in values)
                {
                    Assert.That(value, Is.SubsetOf(caseExpectedValues));
                }
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
                foreach (string value in caseExpectedValues)
                {
                    Assert.That(value, Is.SubsetOf(values));
                }
                foreach (string value in values)
                {
                    Assert.That(value, Is.SubsetOf(caseExpectedValues));
                }
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
        /**/
        /*
        static readonly TestCaseData[] StaticGetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetByKeyTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticGetByKeyTestCases))]
        public void StaticGetByKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticSetByKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticSetByKeyTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticSetByKeyTestCases))]
        public void StaticSetByKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticGetKeysTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetKeysTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticGetKeysTestCases))]
        public void StaticGetKeysTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticGetValuesTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetValuesTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticGetValuesTestCases))]
        public void StaticGetValuesTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticGetCountTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetCountTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticGetCountTestCases))]
        public void StaticGetCountTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, int caseExpectedCount)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticGetIsReadOnlyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticGetIsReadOnlyTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticGetIsReadOnlyTestCases))]
        public void StaticGetIsReadOnlyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticAddElementsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddElementsTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticAddElementsTestCases))]
        public void StaticAddElementsTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticAddPairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticAddPairTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticAddPairTestCases))]
        public void StaticAddPairTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticClearTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticClearTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticClearTestCases))]
        public void StaticClearTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticContainsTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticContainsTestCases))]
        public void StaticContainsTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticContainsKeyTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticContainsKeyTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticContainsKeyTestCases))]
        public void StaticContainsKeyTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticCopyToTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyToTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticCopyToTestCases))]
        public void StaticCopyToTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, System.Object caseExpectedObject)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticPairEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticPairEnumeratorTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticPairEnumeratorTestCases))]
        public void StaticPairEnumeratorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticEnumeratorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticEnumeratorTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticEnumeratorTestCases))]
        public void StaticEnumeratorTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticRemoveTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemoveTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticRemoveTestCases))]
        public void StaticRemoveTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticRemovePairTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticRemovePairTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticRemovePairTestCases))]
        public void StaticRemovePairTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticTryGetValueTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticTryGetValueTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticTryGetValueTestCases))]
        public void StaticTryGetValueTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticNullInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticNullInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticNullInitializerTestCases))]
        public void StaticNullInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticInterfaceCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticInterfaceCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticInterfaceCopyInitializerTestCases))]
        public void StaticInterfaceCopyInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticCopyInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticCopyInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticCopyInitializerTestCases))]
        public void StaticCopyInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticDictionaryInterfaceInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInterfaceInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticDictionaryInterfaceInitializerTestCases))]
        public void StaticDictionaryInterfaceInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticDictionaryInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticDictionaryInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticDictionaryInitializerTestCases))]
        public void StaticDictionaryInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticKVPairInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticKVPairInitializerTestCases))]
        public void StaticKVPairInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticKVPairArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticKVPairArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticKVPairArrayInitializerTestCases))]
        public void StaticKVPairArrayInitializerTest(System.Object caseProvidedObjectInstance, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticElementArraysInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticElementArraysInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticElementArraysInitializerTestCases))]
        public void StaticElementArraysInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        static readonly TestCaseData[] StaticValueArrayInitializerTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(StaticValueArrayInitializerTest), ObjectInterface.TEST_CASE_DATA);
        [Test]
        [TestCaseSource(nameof(StaticValueArrayInitializerTestCases))]
        public void StaticValueArrayInitializerTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        {
            Object obj = new();
            Assert.That((ObjectInterface)obj, Is.EqualTo((ObjectInterface)obj));
        }
        /**/
        /*,
        /*new(nameof(COLTs.NullConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey, DefaultName,
                //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ]))/**//*,
    new(nameof(GenreTests.NullInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.KeyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                CustomGenreKeyString, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.KeyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                CustomGenreKeyString, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.NameConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                CustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.NameInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                CustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.KeyNameConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                AlternateCustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.KeyNameInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                AlternateCustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.IndexConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                1, Genre1String, UnknownGenre1String,
                new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                2, Genre2String, UnknownGenre2String,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.IndexInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                1, Genre1String, UnknownGenre1String,
                new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                2, Genre2String, UnknownGenre2String,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.CopyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                AlternateCustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.CopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializerString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                AlternateCustomGenreKeyString, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.GetKeyAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey
                )
        ])),
    new(nameof(GenreTests.SetKeyAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                Genre1String, DefaultName,
                new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                CustomGenreKeyString, DefaultName,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.GetNameAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultName
                )
        ])),
    new(nameof(GenreTests.SetNameAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey, UnknownGenre1String,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                ),
            new(
                DefaultKey, CustomGenreString,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ])),
    new(nameof(GenreTests.GetCampaignKeysAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey,
                new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns)
                ),
            new(
                Genre1String,
                new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns)
                )
        ])),
    new(nameof(GenreTests.GetPlayerKeysAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey,
                new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players)
                )
        ])),
    new(nameof(GenreTests.GetGameMasterKeysAccessorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                DefaultKey,
                new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                )
        ]))
    /**/
    ]);
}