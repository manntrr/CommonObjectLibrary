namespace CommonObjectLibrary;

using System.Collections;
using Object = CommonObject;
using ObjectInterface = ICommonObject;

public class CommonObject : Dictionary<string, System.Object>, ObjectInterface
{
    public bool isReadOnly { get; set; }
    public ICollection<string> BaseKeys => base.Keys;
    public ICollection<System.Object> BaseValues => base.Values;
    public int BaseCount => base.Count;
    public void BaseAdd(string key, System.Object value) => base.Add(key, value);
    public void BaseAdd(KeyValuePair<string, System.Object> item) => base.Add(item.Key, item.Value);
    public void BaseClear() => base.Clear();
    public bool BaseContains(KeyValuePair<string, System.Object> item) => base.ContainsKey(item.Key) ? base[item.Key] == item.Value : false;
    public bool BaseContainsKey(string key) => base.ContainsKey(key);
    public void BaseCopyTo(KeyValuePair<string, System.Object>[] array, int arrayIndex)
    {
        foreach (KeyValuePair<string, System.Object> pair in array)
        {
            BaseAdd(pair);
        }
        throw new NotImplementedException();
    }
    public IEnumerator<KeyValuePair<string, System.Object>> BaseGetPairEnumerator() => base.GetEnumerator();
    public IEnumerator BaseGetEnumerator() => base.GetEnumerator();
    public bool BaseRemove(string key) => base.Remove(key);
    public bool BaseRemove(KeyValuePair<string, System.Object> item) => base.Remove(item.Key);
    public bool BaseTryGetValue(string key, out System.Object value)
    {
        bool result;
        result = base.TryGetValue(key, out System.Object? temp);
        value = temp ?? new();
        return result;
    }

    new protected System.Object this[string key]
    {
        get => base[key];
        set => base[key] = (Object)value;
    }
    System.Object IDictionary<string, System.Object>.this[string key]
    {
        get => this.GetByKey(key);
        set => this.SetByKey(key, value);
    }
    ICollection<string> IDictionary<string, System.Object>.Keys => this.GetKeys();
    ICollection<System.Object> IDictionary<string, System.Object>.Values => this.GetValues();
    int ICollection<KeyValuePair<string, System.Object>>.Count => this.GetCount();
    bool ICollection<KeyValuePair<string, System.Object>>.IsReadOnly => this.GetIsReadOnly();
    void IDictionary<string, System.Object>.Add(string key, System.Object value) => this.Add(key, value);
    void ICollection<KeyValuePair<string, System.Object>>.Add(KeyValuePair<string, System.Object> item) => this.Add(item);
    void ICollection<KeyValuePair<string, System.Object>>.Clear() => this.Clear();
    bool ICollection<KeyValuePair<string, System.Object>>.Contains(KeyValuePair<string, System.Object> item) => this.Contains(item);
    bool IDictionary<string, System.Object>.ContainsKey(string key) => this.ContainsKey(key);
    void ICollection<KeyValuePair<string, System.Object>>.CopyTo(KeyValuePair<string, System.Object>[] array, int arrayIndex) => this.CopyTo(array, arrayIndex);
    IEnumerator<KeyValuePair<string, System.Object>> IEnumerable<KeyValuePair<string, System.Object>>.GetEnumerator() => this.GetPairEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    bool IDictionary<string, System.Object>.Remove(string key) => this.Remove(key);
    bool ICollection<KeyValuePair<string, System.Object>>.Remove(KeyValuePair<string, System.Object> item) => this.Remove(item);
    bool IDictionary<string, System.Object>.TryGetValue(string key, out System.Object value) => this.TryGetValue(key, out value);
    public System.Object GetByKey(string key) => ObjectInterface.GET_BY_KEY(this, key);
    public void SetByKey(string key, System.Object value) => ObjectInterface.SET_BY_KEY(this, key, value);
    public ICollection<string> GetKeys() => ObjectInterface.GET_KEYS(this);
    public ICollection<System.Object> GetValues() => ObjectInterface.GET_VALUES(this);
    public int GetCount() => ObjectInterface.GET_COUNT(this);
    public bool GetIsReadOnly() => ObjectInterface.GET_IS_READ_ONLY(this);
    new public void Add(string key, System.Object value) => ObjectInterface.ADD(this, key, value);
    public void Add(KeyValuePair<string, System.Object> item) => ObjectInterface.ADD(this, item);
    new public void Clear() => ObjectInterface.CLEAR(this);
    public bool Contains(KeyValuePair<string, System.Object> item) => ObjectInterface.CONTAINS(this, item);
    new public bool ContainsKey(string key) => ObjectInterface.CONTAINS_KEY(this, key);
    public void CopyTo(KeyValuePair<string, System.Object>[] array, int arrayIndex) => ObjectInterface.COPY_TO(this, array, arrayIndex);
    public IEnumerator<KeyValuePair<string, System.Object>> GetPairEnumerator() => ObjectInterface.GET_PAIR_ENUMERATOR(this);
    new public IEnumerator GetEnumerator() => ObjectInterface.GET_ENUMERATOR(this);
    new public bool Remove(string key) => ObjectInterface.REMOVE(this, key);
    public bool Remove(KeyValuePair<string, System.Object> item) => ObjectInterface.REMOVE(this, item);
    new public bool TryGetValue(string key, out System.Object value) => ObjectInterface.TRY_GET_VALUE(this, key, out value);
    public CommonObject() : base() => Init();
    public CommonObject(ObjectInterface obj) => Init(obj);
    public CommonObject(Object obj) => Init(obj);
    public CommonObject(IDictionary<string, System.Object> obj) => Init(obj);
    public CommonObject(Dictionary<string, System.Object> obj) => Init(obj);
    public CommonObject(KeyValuePair<string, System.Object> obj) => Init(obj);
    public CommonObject(KeyValuePair<string, System.Object>[] objs) => Init(objs);
    public CommonObject(string[] keys, System.Object[] objs) => Init(keys, objs);
    public CommonObject(System.Object[] objs) => Init(objs);
    public void Init() => ObjectInterface.INIT(this);
    public void Init(ObjectInterface obj) => ObjectInterface.INIT(this, obj);
    public void Init(Object obj) => ObjectInterface.INIT(this, obj);
    public void Init(IDictionary<string, System.Object> obj) => ObjectInterface.INIT(this, obj);
    public void Init(Dictionary<string, System.Object> obj) => ObjectInterface.INIT(this, obj);
    public void Init(KeyValuePair<string, System.Object> obj) => ObjectInterface.INIT(this, obj);
    public void Init(KeyValuePair<string, System.Object>[] objs) => ObjectInterface.INIT(this, objs);
    public void Init(string[] keys, System.Object[] objs) => ObjectInterface.INIT(this, keys, objs);
    public void Init(System.Object[] objs) => ObjectInterface.INIT(this, objs);
}
