namespace CommonObjectLibrary;

using System.Collections;
using Object = CommonObject;
using ObjectInterface = ICommonObject;

public class CommonObject : Dictionary<string, Object>, ObjectInterface
{
    public bool isReadOnly { get; set; }
    public ICollection<string> BaseKeys => base.Keys;
    public ICollection<Object> BaseValues => base.Values;
    public int BaseCount => base.Count;
    public void BaseAdd(string key, Object value) => base.Add(key, value);
    public void BaseAdd(KeyValuePair<string, Object> item) => base.Add(item.Key, item.Value);
    public void BaseClear() => base.Clear();
    public bool BaseContains(KeyValuePair<string, Object> item) => base.ContainsKey(item.Key) ? base[item.Key] == item.Value : false;
    public bool BaseContainsKey(string key) => base.ContainsKey(key);
    public void BaseCopyTo(KeyValuePair<string, Object>[] array, int arrayIndex)
    {
        foreach (KeyValuePair<string, Object> pair in array)
        {
            BaseAdd(pair);
        }
        throw new NotImplementedException();
    }
    public IEnumerator<KeyValuePair<string, Object>> BaseGetPairEnumerator() => base.GetEnumerator();
    public IEnumerator BaseGetEnumerator() => base.GetEnumerator();
    public bool BaseRemove(string key) => base.Remove(key);
    public bool BaseRemove(KeyValuePair<string, Object> item) => base.Remove(item.Key);
    public bool BaseTryGetValue(string key, out Object value) => base.TryGetValue(key, out value);

    new protected ObjectInterface this[string key]
    {
        get => base[key];
        set => base[key] = (Object)value;
    }
    ObjectInterface IDictionary<string, ObjectInterface>.this[string key]
    {
        get => this.GetByKey(key);
        set => this.SetByKey(key, value);
    }
    ICollection<string> IDictionary<string, ObjectInterface>.Keys => this.GetKeys();
    ICollection<ObjectInterface> IDictionary<string, ObjectInterface>.Values => this.GetValues();
    int ICollection<KeyValuePair<string, ObjectInterface>>.Count => this.GetCount();
    bool ICollection<KeyValuePair<string, ObjectInterface>>.IsReadOnly => this.GetIsReadOnly();
    void IDictionary<string, ObjectInterface>.Add(string key, ObjectInterface value) => this.Add(key, value);
    void ICollection<KeyValuePair<string, ObjectInterface>>.Add(KeyValuePair<string, ObjectInterface> item) => this.Add(item);
    void ICollection<KeyValuePair<string, ObjectInterface>>.Clear() => this.Clear();
    bool ICollection<KeyValuePair<string, ObjectInterface>>.Contains(KeyValuePair<string, ObjectInterface> item) => this.Contains(item);
    bool IDictionary<string, ObjectInterface>.ContainsKey(string key) => this.ContainsKey(key);
    void ICollection<KeyValuePair<string, ObjectInterface>>.CopyTo(KeyValuePair<string, ObjectInterface>[] array, int arrayIndex) => this.CopyTo(array, arrayIndex);
    IEnumerator<KeyValuePair<string, ObjectInterface>> IEnumerable<KeyValuePair<string, ObjectInterface>>.GetEnumerator() => this.GetPairEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    bool IDictionary<string, ObjectInterface>.Remove(string key) => this.Remove(key);
    bool ICollection<KeyValuePair<string, ObjectInterface>>.Remove(KeyValuePair<string, ObjectInterface> item) => this.Remove(item);
    bool IDictionary<string, ObjectInterface>.TryGetValue(string key, out ObjectInterface value) => this.TryGetValue(key, out value);
    public ObjectInterface GetByKey(string key) => ObjectInterface.GET_BY_KEY(this, key);
    public void SetByKey(string key, ObjectInterface value) => ObjectInterface.SET_BY_KEY(this, key, value);
    public ICollection<string> GetKeys() => ObjectInterface.GET_KEYS(this);
    public ICollection<ObjectInterface> GetValues() => ObjectInterface.GET_VALUES(this);
    public int GetCount() => ObjectInterface.GET_COUNT(this);
    public bool GetIsReadOnly() => ObjectInterface.GET_IS_READ_ONLY(this);
    public void Add(string key, ObjectInterface value) => ObjectInterface.ADD(this, key, value);
    public void Add(KeyValuePair<string, ObjectInterface> item) => ObjectInterface.ADD(this, item);
    new public void Clear() => ObjectInterface.CLEAR(this);
    public bool Contains(KeyValuePair<string, ObjectInterface> item) => ObjectInterface.CONTAINS(this, item);
    new public bool ContainsKey(string key) => ObjectInterface.CONTAINS_KEY(this, key);
    public void CopyTo(KeyValuePair<string, ObjectInterface>[] array, int arrayIndex) => ObjectInterface.COPY_TO(this, array, arrayIndex);
    public IEnumerator<KeyValuePair<string, ObjectInterface>> GetPairEnumerator() => ObjectInterface.GET_PAIR_ENUMERATOR(this);
    new public IEnumerator GetEnumerator() => ObjectInterface.GET_ENUMERATOR(this);
    new public bool Remove(string key) => ObjectInterface.REMOVE(this, key);
    public bool Remove(KeyValuePair<string, ObjectInterface> item) => ObjectInterface.REMOVE(this, item);
    public bool TryGetValue(string key, out ObjectInterface value) => ObjectInterface.TRY_GET_VALUE(this, key, out value);
}
