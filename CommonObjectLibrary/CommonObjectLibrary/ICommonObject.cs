namespace CommonObjectLibrary;

using System.Collections;

using Object = CommonObject;
using ObjectInterface = ICommonObject;
using TCDD = /*NUnit.Framework./**/TestCaseDataDictionary;
using TCsDD = /*NUnit.Framework./**/TestCasesDataDictionary;
using COLTs = TestCommonObjectLibrary.ILibraryTests;
using InvalidArgumentException = NUnit.Framework.InvalidArgumentException;
using System.Runtime.Serialization;
using System.Xml.Serialization;

// TODO:  add interfaces to the object
public interface ICommonObject : IDictionary<string, System.Object>, IComparable//, ISerializable, IXmlSerializable, IJSONSerializable, ISet<KeyValuePair<string, System.Object>>, ISet<string>, ISet<System.Object>, IList<KeyValuePair<string, System.Object>>, IList<string>, IList<System.Object>
{
    private static int counter = 0;
    int IComparable.CompareTo(object? obj) => CompareTo(obj);
    new public int CompareTo(object? obj);
    static public int COMPARE_TO(ObjectInterface _object, object? obj)
    {
        if (_object is not null && obj is not null && obj is ObjectInterface)
        {
            ObjectInterface second = (ObjectInterface)obj;
            if (_object.Keys is not null && second.Keys is not null)
            {
                int temp = _object.Keys.Count - second.Keys.Count;
                if (temp == 0)
                {
                    string firstKeys = "", secondKeys = "", sep = "";
                    IEnumerator<string> keysEnum = _object.Keys.OrderDescending().Reverse().GetEnumerator();
                    while (keysEnum.MoveNext())
                    {
                        firstKeys += sep;
                        if (_object.KeyCaseSensative)
                        {
                            firstKeys += keysEnum.Current;
                        }
                        else
                        {
                            firstKeys += keysEnum.Current.ToLower();
                        }
                        sep = ",";
                    }
                    sep = "";
                    keysEnum = second.Keys.OrderDescending().Reverse().GetEnumerator();
                    while (keysEnum.MoveNext())
                    {
                        secondKeys += sep;
                        if (second.KeyCaseSensative)
                        {
                            secondKeys += keysEnum.Current;
                        }
                        else
                        {
                            secondKeys += keysEnum.Current.ToLower();
                        }
                        sep = ",";
                    }
                    sep = "";
                    temp = firstKeys.CompareTo(secondKeys);
                    if (temp == 0)
                    {
                        foreach (string key in _object.Keys)
                        {
                            var firstValue = _object[key];
                            var secondValue = second[key];
                            if (firstValue is IComparable && secondValue is IComparable)
                            {
                                temp = ((IComparable)firstValue).CompareTo((IComparable)secondValue);
                            }
                            else if (firstValue is not IComparable && secondValue is not IComparable)
                            {
                                temp = 0;
                            }
                            else if (firstValue is IComparable)
                            {
                                temp = 1;
                                break;
                            }
                            else
                            {
                                temp = -1;
                                break;
                            }
                            if (temp != 0)
                            {
                                break;
                            }
                        }
                        return temp;
                    }
                    else
                    {
                        return temp;
                    }
                }
                else
                {
                    return temp;
                }
            }
            else
            {
                if (_object.Keys is null && second.Keys is null)
                {
                    return 0;
                }
                else if (_object.Keys is null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        else
        {
            if (obj is ObjectInterface)
            {
                if (_object is null && obj is null)
                {
                    return 0;
                }
                else if (_object is null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                // TODO: throw invalid argumnet exception
                return -1;
            }
        }
    }
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
    public bool KeyCaseSensative { get; }
    public bool GetKeyCaseSensative();
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
    public void Init(bool isReadOnly = false);
    public void Init(ObjectInterface originalObject, bool isReadOnly = false);
    public void Init(Object originalObject, bool isReadOnly = false);
    public void Init(IDictionary<string, System.Object> originalObject, bool isReadOnly = false);
    public void Init(Dictionary<string, System.Object> originalObject, bool isReadOnly = false);
    public void Init(KeyValuePair<string, System.Object> originalObject, bool isReadOnly = false);
    public void Init(KeyValuePair<string, System.Object>[] objects, bool isReadOnly = false);
    public void Init(string[] keys, System.Object[] objects, bool isReadOnly = false);
    public void Init(System.Object[] objects, bool isReadOnly = false);

    // cannot have GetByKey call this - causes stack overflow
    public static System.Object GET_BY_KEY(ObjectInterface _object, string key)
    {
        return _object[key];
    }
    // cannot have SetByKey call this - causes stack overflow
    public static void SET_BY_KEY(ObjectInterface _object, string key, System.Object value)
    {
        if (!GET_IS_READ_ONLY(_object)) _object[key] = value;
        else throw new InvalidOperationException("Attempt to set a key value on an object that is read only!");
    }
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
    public static bool GET_KEY_CASE_SENSATIVE(ObjectInterface _object)
    {
        // StringComparer.OrdinalIgnoreCase
        return ((Dictionary<string, System.Object>)_object).Comparer.Equals(StringComparer.Ordinal);
    }
    public static void ADD(ObjectInterface _object, string key, System.Object value)
    {
        if (!GET_IS_READ_ONLY(_object)) _object.BaseAdd(key, (System.Object)value);
        else throw new InvalidOperationException("Attempt to add a key value on an object that is read only!");
    }
    public static void ADD(ObjectInterface _object, KeyValuePair<string, System.Object> item)
    {
        if (!GET_IS_READ_ONLY(_object)) _object.BaseAdd(new KeyValuePair<string, System.Object>(key: item.Key, value: (System.Object)item.Value));
        else throw new InvalidOperationException("Attempt to add a key value on an object that is read only!");
    }
    public static void CLEAR(ObjectInterface _object)
    {
        if (!GET_IS_READ_ONLY(_object)) _object.BaseClear();
        else throw new InvalidOperationException("Attempt to clear an object that is read only!");
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
        if ((arrayIndex <= array.Length) && (arrayIndex < keys.Length)) for (int i = arrayIndex; ((i - arrayIndex) < array.Length) && (i < keys.Length); i++) array[i - arrayIndex] = new(key: keys.ElementAt(i), value: _object[keys.ElementAt(i)]);
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
        if (!GET_IS_READ_ONLY(_object)) return _object.BaseRemove(key);
        else throw new InvalidOperationException("Attempt to remove a key value on an object that is read only!");
    }
    public static bool REMOVE(ObjectInterface _object, KeyValuePair<string, System.Object> item)
    {
        if (!GET_IS_READ_ONLY(_object)) return _object.BaseRemove(new KeyValuePair<string, System.Object>(key: item.Key, value: (System.Object)item.Value));
        else throw new InvalidOperationException("Attempt to remove a key value pair on an object that is read only!");
    }
    public static bool TRY_GET_VALUE(ObjectInterface _object, string key, out System.Object value)
    {
        System.Object temp;
        bool result = _object.BaseTryGetValue(key, out temp);
        value = temp;
        return result;
    }
    public static void INIT(ObjectInterface newObject, bool isReadOnly = false)
    {
        if (GET_IS_READ_ONLY(newObject)) throw new InvalidOperationException("Attempt to initialize an object that is read only!");
        var keyList = GET_KEYS(newObject);
        foreach (string key in keyList)
        {
            REMOVE(newObject, key: key);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, ObjectInterface interfaceObject, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        foreach (KeyValuePair<string, System.Object> pair in interfaceObject)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, Object obj, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        foreach (KeyValuePair<string, System.Object> pair in obj)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, IDictionary<string, System.Object> dictionaryInterface, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        foreach (KeyValuePair<string, System.Object> pair in dictionaryInterface)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, Dictionary<string, System.Object> dictionary, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        foreach (KeyValuePair<string, System.Object> pair in dictionary)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object> keyValuePair, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        if (keyValuePair.Key is not null) ADD(newObject, key: keyValuePair.Key, value: keyValuePair.Value);
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object>[] keyValuePairArray, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        foreach (KeyValuePair<string, System.Object> pair in keyValuePairArray)
        {
            ADD(newObject, key: pair.Key, value: pair.Value);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, string[] keys, System.Object[] values, bool isReadOnly = false)
    {
        if (keys.Length != values.Length) throw new InvalidArgumentException("Object Initialization key array length does not match the values array length!");
        INIT(newObject, isReadOnly: false);
        for (int index = 0; index < keys.Length; index++)
        {
            ADD(newObject, key: keys[index], value: values[index]);
        }
        newObject.isReadOnly = isReadOnly;
    }
    public static void INIT(ObjectInterface newObject, System.Object[] values, bool isReadOnly = false)
    {
        INIT(newObject, isReadOnly: false);
        for (int index = 0; index < values.Length; index++)
        {
            ADD(newObject, key: values[index].ToString() ?? "", value: values[index]);
        }
        newObject.isReadOnly = isReadOnly;
    }
    static readonly TCsDD TEST_CASE_DATA = new([
        new(nameof(COLTs.GetByKeyOperationTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void GetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                )
        ])),
        new(nameof(COLTs.GetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString, TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void GetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                )
        ])),
        new(nameof(COLTs.SetByKeyOperationTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void SetByKeyOperationTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                )
        ])),
        new(nameof(COLTs.SetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void SetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                )
        ])),
        new(nameof(COLTs.GetKeysPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void GetKeysPropertyTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") }), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") },isReadOnly:true), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true,keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                )
        ])),
        new(nameof(COLTs.GetKeysFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void GetKeysFunctionTest(System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") }), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") },isReadOnly:true), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true,keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                )
        ])),
        new(nameof(COLTs.GetValuesPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void GetValuesPropertyTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") }), new[] {"test","test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test","test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test","test","test"}, null
                )
        ])),
        new(nameof(COLTs.GetValuesFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test","test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test","test","test"}, null
                )/**/
        ])),
        new(nameof(COLTs.GetCountPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/, TCDD.AccessorString, TCDD.AccessorString, TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void GetCountPropertyTest(System.Object caseProvidedObject, int caseExpectedCount)
        TestCaseData: new TestCaseData[] {
            new(
                //System.Object caseProvidedObject, int caseExpectedCount
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), 0, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), 1, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), 2, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), 3, null
                )/**/
        })),
        new(nameof(COLTs.GetCountFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/, TCDD.AccessorString, TCDD.AccessorString, TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void GetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount)
        TestCaseData: new TestCaseData[] {
            new(
                //System.Object caseProvidedObject, int caseExpectedCount
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), 0, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), 1, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), 2, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), 3, null
                )/**/
        })),
        new(nameof(COLTs.GetIsReadOnlyPropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetIsReadOnlyPropertyTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedIsReadOnly
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), false, null
                )/**/
        ])),
        new(nameof(COLTs.GetIsReadOnlyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedIsReadOnly
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), false, null
                )/**/
        ])),
        new(nameof(COLTs.GetKeyCaseSensativePropertyTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetKeyCaseSensativePropertyTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), true, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), true, null
                )/**/
        ])),
        new(nameof(COLTs.GetKeyCaseSensativeFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void GetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), true, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), true, null
                )/**/
        ])),
        new(nameof(COLTs.AddElementsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void AddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", "test", "test A", "test", null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", "test", "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", "test", "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", "test", "test D", "test", null
                )/**/
        ])),
        new(nameof(COLTs.AddPairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void AddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key:"test A", value: "test"), "test A", "test", null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key:"test B", value: "test"), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key:"test C", value: "test"), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key:"test D", value: "test"), "test D", "test", null
                )/**/
        ])),
        new(nameof(COLTs.ClearFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ClearFunctionTest(System.Object caseProvidedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.ContainsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test C", value: "test"), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test D", value: "test"), false, null
                )/**/
        ])),
        new(nameof(COLTs.ContainsKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void ContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false, null
                )/**/
        ])),
        new(nameof(COLTs.CopyToFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[1], null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[3], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test"), new("test C", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[1], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test") }, null
                )/**/
        ])),
        new(nameof(COLTs.PairEnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void PairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator(), null
                )/**/
        ])),
        new(nameof(COLTs.EnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void EnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator(), null
                )/**/
        ])),
        new(nameof(COLTs.RemoveFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void RemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.RemovePairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void RemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>("",""), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test!"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test C","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test D","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.TryGetValueFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        TryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", false, new System.Object(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false, new System.Object(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false, new System.Object(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false, new System.Object(), null
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
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )
        ])),
        new(nameof(COLTs.NullInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString()/**/],
        //        public void NullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/
        ])),
        new(nameof(COLTs.InterfaceCopyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString()/**/],
        //        public void InterfaceCopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.InterfaceCopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void InterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.CopyConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyConstructorTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.CopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void CopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInterfaceConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/,TCDD.ConstructorString,TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString()/**/],
        //        public void DictionaryInterfaceConstructorTest(IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue
                new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" } } , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") }), null
                ),
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new ("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInterfaceInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.DictionaryConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryConstructorTest(Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue
                new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" } } , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") }), null
                ),
            new(
                new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new ("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.DictionaryInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void DictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.KVPairConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString()/**/],
        //        public void KVPairConstructorTest(KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue
                new KeyValuePair<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new KeyValuePair<string, System.Object>("test A", "test") , new CommonObject(new KeyValuePair<string, System.Object>[] { new ("test A", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.KVPairInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.KVPairArrayConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairArrayConstructorTest(KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue
                new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                )/**/,
            new(
                new KeyValuePair<string, System.Object>[] { new("test A", "test") } , new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new KeyValuePair<string, System.Object>[] { new ("test A", "test"), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.KVPairArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void KVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.ElementArraysConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString()/**/],
        //        public void ElementArraysConstructorTest(string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new string[0], new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.ElementArraysInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void ElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new string[0], new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[0], new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[0], new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.ValueArrayConstructorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.ConstructorString/**/, TCDD.ConstructorString, TCDD.ConstructorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString()/**/],
        //        public void ValueArrayConstructorTest(System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.ValueArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void ValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.StaticGetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void StaticGetByKeyFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue, Exception caseExpectedException
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test c", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", null, new KeyNotFoundException("The given key 'test a' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", null, new KeyNotFoundException("The given key 'test b' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", null, new KeyNotFoundException("The given key 'test' was not present in the dictionary.")
                )
        ])),
        new(nameof(COLTs.StaticSetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void StaticSetByKeyFunctionTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test A", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test B", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test a", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test b", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, keyCaseSensative: false), "test", "test", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test A", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test B", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true), "test a", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true), "test b", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, isReadOnly: true, keyCaseSensative: false), "test", "test", null, new InvalidOperationException("Attempt to set a key value on an object that is read only!")
                )
        ])),
        new(nameof(COLTs.StaticGetKeysFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString],
        TestCaseCategories: [TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString],
        TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()],
        //        public void StaticGetKeysFunctionTest(System.Object caseProvidedObjectInstance, System.Object caseProvidedObject, ICollection<string> caseExpectedKeys)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<string> caseExpectedKeys
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") }), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test a", "test") },isReadOnly:true), new[] {"test A", "test a"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true), new[] {"test A", "test B", "test C"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { },isReadOnly:true,keyCaseSensative:false), new string[] {}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") },isReadOnly:true,keyCaseSensative:false), new[] {"test A", "test B", "test C"}, null
                )
        ])),
        new(nameof(COLTs.StaticGetValuesFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticGetValuesFunctionTest(System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, ICollection<System.Object> caseExpectedValues
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new string[] {}, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new[] {"test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new[] {"test","test"}, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new[] {"test","test","test"}, null
                )/**/
        ])),
        new(nameof(COLTs.StaticGetCountFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/, TCDD.AccessorString, TCDD.AccessorString, TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticGetCountFunctionTest(System.Object caseProvidedObject, int caseExpectedCount)
        TestCaseData: new TestCaseData[] {
            new(
                //System.Object caseProvidedObject, int caseExpectedCount
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), 0, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), 1, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), 2, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), 3, null
                )/**/
        })),
        new(nameof(COLTs.StaticGetIsReadOnlyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticGetIsReadOnlyFunctionTest(System.Object caseProvidedObject, bool caseExpectedIsReadOnly)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedIsReadOnly
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), false, null
                )/**/
        ])),
        new(nameof(COLTs.StaticGetKeyCaseSensativeFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticGetKeyCaseSensativeFunctionTest(System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, bool caseExpectedKeyCaseSensative
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), true, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), true, null
                )/**/
        ])),
        new(nameof(COLTs.StaticAddElementsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticAddElementsFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseProvidedValue, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", "test", "test A", "test", null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", "test", "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", "test", "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", "test", "test D", "test", null
                )/**/
        ])),
        new(nameof(COLTs.StaticAddPairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticAddPairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, string caseExpectedKey, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key:"test A", value: "test"), "test A", "test", null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key:"test B", value: "test"), "test B", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key:"test C", value: "test"), "test C", "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key:"test D", value: "test"), "test D", "test", null
                )/**/
        ])),
        new(nameof(COLTs.StaticClearFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticClearFunctionTest(System.Object caseProvidedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticContainsFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticContainsFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseRequestedValue, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test A", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(key: "test C", value: "test"), false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test B", value: "test"), true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>(key: "test D", value: "test"), false, null
                )/**/
        ])),
        new(nameof(COLTs.StaticContainsKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticContainsKeyFunctionTest(System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseRequestedKey, bool caseExpectedResult
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "test A", false, null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false, null
                )/**/
        ])),
        new(nameof(COLTs.StaticCopyToFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticCopyToFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object>[] caseProvidedArray, int caseProvidedArrayIndex, KeyValuePair<string, System.Object>[] caseExpectedArray
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[1], null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[1], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[3], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 0, new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[2], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test"), new("test C", "test") }, null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>[1], 1, new KeyValuePair<string, System.Object>[] { new("test B", "test") }, null
                )/**/
        ])),
        new(nameof(COLTs.StaticPairEnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticPairEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator<KeyValuePair<string, System.Object>> caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator(), null
                )/**/
        ])),
        new(nameof(COLTs.StaticEnumeratorFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticEnumeratorFunctionTest(System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, IEnumerator caseExpectedEnumerator
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new List<KeyValuePair<string, System.Object>> { }.GetEnumerator(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test") }.GetEnumerator(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new List<KeyValuePair<string, System.Object>> { new("test A", "test"), new("test B", "test"), new("test C", "test") }.GetEnumerator(), null
                )/**/
        ])),
        new(nameof(COLTs.StaticRemoveFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticRemoveFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test A", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticRemovePairFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticRemovePairFunctionTest(System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, KeyValuePair<string, System.Object> caseProvidedPair, System.Object caseExpectedObject
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new KeyValuePair<string, System.Object>("",""), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A","test!"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test C","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test B","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test C", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), new KeyValuePair<string, System.Object>("test D","test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticTryGetValueFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.AccessorString/**/,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString,TCDD.AccessorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticTryGetValueFunctionTest(System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, bool caseExpectedResult, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), "", false, new System.Object(), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test A", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), "test B", false, new System.Object(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test B", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), "test C", false, new System.Object(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test B", true, "test", null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test"), new("test C", "test") }), "test D", false, new System.Object(), null
                )/**/
        ])),
        new(nameof(COLTs.StaticNullInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticNullInitializerTest(System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(new KeyValuePair<string, System.Object>[] { }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/,
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticInterfaceCopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticInterfaceCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticCopyInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString,TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString,TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/,counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString(),counter++.ToString()/**/],
        //        public void StaticCopyInitializerTest(System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object caseProvidedObject, System.Object caseExpectedValue
                new CommonObject(), new CommonObject(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticDictionaryInterfaceInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticDictionaryInterfaceInitializerTest(System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, IDictionary<string, System.Object> caseProvidedDictionaryInterface, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticDictionaryInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticDictionaryInitializerTest(System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, Dictionary<string, System.Object> caseProvidedDictionary, System.Object caseExpectedValue
                new CommonObject(), new Dictionary<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test" } }, new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticKVPairInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticKVPairInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object> caseProvidedKVPair, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>(), new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>("test A", "test"), new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), null
                )/**/
        ])),
        new(nameof(COLTs.StaticKVPairArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticKVPairArrayInitializerTest(System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, KeyValuePair<string, System.Object>[] caseProvidedKVPairArray, System.Object caseExpectedValue
                new CommonObject(), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(), new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test") }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new KeyValuePair<string, System.Object>[] { new( "test A", "test" ), new("test B", "test" ) }, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.StaticElementArraysInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticElementArraysInitializerTest(System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, string[] caseProvidedKeyArray, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new string[0], new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[0], new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[0], new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A"}, new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new string[] {"test A", "test B"}, new System.Object[] {"test", "test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test" }, {"test B", "test"} } ), null
                )/**/
        ])),
        new(nameof(COLTs.StaticValueArrayInitializerTest), new(
        TestCaseDescriptions: [TCDD.EmptyString/**/, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString/**/],
        TestCaseCategories: [TCDD.InitializorString/**/, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString, TCDD.InitializorString/**/],
        TestCaseIds: [counter++.ToString()/**/, counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString(), counter++.ToString()/**/],
        //        public void StaticValueArrayInitializerTest(System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue)
        TestCaseData: [
            new(
                //System.Object caseProvidedInitialObject, System.Object[] caseProvidedValueArray, System.Object caseExpectedValue
                new CommonObject(), new System.Object[0], new CommonObject(), null
                )/**/,
            new(
                new CommonObject(), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test") }), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[0], new CommonObject(), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test", "test" } }), null
                ),
            new(
                new CommonObject(new KeyValuePair<string, System.Object>[] { new("test A", "test"), new("test B", "test") }), new System.Object[] {"test A", "test B"}, new CommonObject(new Dictionary<string, System.Object>(){ { "test A", "test A" }, {"test B", "test B"} } ), null
                )/**/
        ]))
    ]);
}