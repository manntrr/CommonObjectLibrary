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
        string[] keys = _object.GetKeys().OrderDescending().Reverse().ToArray<string>();
        if ((arrayIndex < array.Length) && (arrayIndex < keys.Length)) for (int i = arrayIndex; (i < array.Length) && (i < keys.Length); i++) array[i] = new(key: keys.ElementAt(i), value: _object[keys.ElementAt(i)]);
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
        new(nameof(COLTs.GetByKeyOperationTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void GetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test"
                )/**/
        ])),
        new(nameof(COLTs.GetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void GetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test"
                )/**/
        ])),
        new(nameof(COLTs.SetByKeyOperationTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void SetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test", "test", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", "test"
                )/**/
        ])),
        new(nameof(COLTs.SetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void SetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test", "test", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", "test"
                )/**/
        ])),
        new(nameof(COLTs.GetKeysPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetKeysPropertyTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test A"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test A", "test B"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test A", "test B", "test C"}
                )/**/
        ])),
        new(nameof(COLTs.GetKeysFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test A"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test A", "test B"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test A", "test B", "test C"}
                )/**/
        ])),
        new(nameof(COLTs.GetValuesPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetValuesPropertyTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test","test"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test","test","test"}
                )/**/
        ])),
        new(nameof(COLTs.GetValuesFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test","test"}
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test","test","test"}
                )/**/
        ])),
        new(nameof(COLTs.GetCountPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*, TCDD.AccessorString, TCDD.AccessorString, TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount)
        TestCaseData: new TestCaseData[] {
            new(
                //System.Object caseProvidedObject, int caseExpectedCount
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), 0
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), 1
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), 2
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), 3
                )/**/
        })),
        new(nameof(COLTs.GetCountFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*, TCDD.AccessorString, TCDD.AccessorString, TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount)
        TestCaseData: new TestCaseData[] {
            new(
                //System.Object caseProvidedObject, int caseExpectedCount
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), 0
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), 1
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), 2
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), 3
                )/**/
        })),
        new(nameof(COLTs.GetIsReadOnlyPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedIsReadOnly
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), false
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), false
                )/**/
        ])),
        new(nameof(COLTs.GetIsReadOnlyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedIsReadOnly
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), false
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), false
                )/**/
        ])),
        new(nameof(COLTs.AddElementsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void AddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", "test", "test A", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", "test", "test B", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", "test", "test C", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", "test", "test D", "test"
                )/**/
        ])),
        new(nameof(COLTs.AddPairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void AddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key:"test A", value: "test"), "test A", "test"
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key:"test B", value: "test"), "test B", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key:"test C", value: "test"), "test C", "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key:"test D", value: "test"), "test D", "test"
                )/**/
        ])),
        new(nameof(COLTs.ClearFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ClearFunctionTest(System.Object caseProvidedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") })
                )/**/
        ])),
        new(nameof(COLTs.ContainsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), false
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test C", value: "test"), false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test D", value: "test"), false
                )/**/
        ])),
        new(nameof(COLTs.ContainsKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", false
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false
                )/**/
        ])),
        new(nameof(COLTs.CopyToFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[1]
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test") }
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[3], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test"), new("test C", "test") }
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[1], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test") }
                )/**/
        ])),
        new(nameof(COLTs.PairEnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void PairEnumeratorTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator()
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator()
                )/**/
        ])),
        new(nameof(COLTs.EnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void EnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator()
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator()
                )/**/
        ])),
        new(nameof(COLTs.RemoveFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void RemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") })
                )/**/
        ])),
        new(nameof(COLTs.RemovePairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void RemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>("",""), new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test!"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test C","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test D","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") })
                )/**/
        ])),
        new(nameof(COLTs.TryGetValueFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/*,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        TryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", false, new System.Object()
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true, "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false, new System.Object()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", true, "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false, new System.Object()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true, "test"
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false, new System.Object()
                )/**/
        ])),
        new(nameof(COLTs.NullConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        //        public void NullConstructorTest(System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )
        ])),
        new(nameof(COLTs.NullInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { })
                )/**/
        ])),
        new(nameof(COLTs.InterfaceCopyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject()
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.InterfaceCopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject()
                )/*,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.CopyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject()
                )/*,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.CopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject()
                )/*,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInterfaceConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*,counter++.ToString(),counter++.ToString()/**/],
        //        public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue
                new Dictionary<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" } } , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") })
                ),
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new ("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInterfaceInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.DictionaryConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue
                new Dictionary<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" } } , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") })
                ),
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new ("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") })
                )/**/
        ])),
        new(nameof(COLTs.KVPairConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString()/**/],
        //        public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue
                new KeyValuePair<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new KeyValuePair<string, System.Object>("test A", "test") , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") })
                )/**/
        ])),
        new(nameof(COLTs.KVPairInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>(), new CommonObject()
                )/*,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") })
                )/**/
        ])),
        new(nameof(COLTs.KVPairArrayConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue
                new KeyValuePair<string, System.Object>[0], new CommonObject()
                )/*,
            new(
                new KeyValuePair<string, System.Object>[] { new("test A", "test") } , new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ])),
        new(nameof(COLTs.KVPairArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>[0], new CommonObject()
                )/*,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ])),
        new(nameof(COLTs.ElementArraysConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString()/**/],
        //        public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new string[0], new System.Object[0], new CommonObject()
                )/*,
            new(
                new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ])),
        new(nameof(COLTs.ElementArraysInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new string[0], new System.Object[0], new CommonObject()
                )/*,
            new(
                new CommonObject(), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[0], new System.Object[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[0], new System.Object[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ])),
        new(nameof(COLTs.ValueArrayConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/*, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString()/**/],
        //        public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new System.Object[0], new CommonObject()
                )/*,
            new(
                new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ])),
        new(nameof(COLTs.ValueArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/*, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/*, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/*, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new System.Object[0], new CommonObject()
                )/*,
            new(
                new CommonObject(), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(), new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[0], new CommonObject()
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } })
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } )
                )/**/
        ]))/**/
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