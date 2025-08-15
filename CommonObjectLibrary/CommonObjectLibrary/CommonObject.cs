using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CommonObjectLibrary;

public class CommonObject : Dictionary<string, CommonObject>, ICommonObject
{
    public bool isReadOnly { get; set; }
    public ICollection<string> BaseKeys => base.Keys;
    public ICollection<CommonObject> BaseValues => base.Values;
    public int BaseCount => base.Count;
    public void BaseAdd(string key, CommonObject value) => base.Add(key, value);
    public void BaseAdd(KeyValuePair<string, CommonObject> item) => base.Add(item.Key, item.Value);
    public void BaseClear() => base.Clear();
    public bool BaseContains(KeyValuePair<string, CommonObject> item) => base.ContainsKey(item.Key) ? base[item.Key] == item.Value : false;
    public bool BaseContainsKey(string key) => base.ContainsKey(key);
    public void BaseCopyTo(KeyValuePair<string, CommonObject>[] array, int arrayIndex)
    {
        foreach (KeyValuePair<string, CommonObject> pair in array)
        {
            BaseAdd(pair);
        }
        throw new NotImplementedException();
    }
    public IEnumerator<KeyValuePair<string, CommonObject>> BaseGetPairEnumerator() => base.GetEnumerator();
    public IEnumerator BaseGetEnumerator() => base.GetEnumerator();
    public bool BaseRemove(string key) => base.Remove(key);
    public bool BaseRemove(KeyValuePair<string, CommonObject> item) => base.Remove(item.Key);
    public bool BaseTryGetValue(string key, out CommonObject value) => base.TryGetValue(key, out value);

    new protected ICommonObject this[string key]
    {
        get => base[key];
        set => base[key] = (CommonObject)value;
    }
    ICommonObject IDictionary<string, ICommonObject>.this[string key]
    {
        get => this.GetByKey(key);
        set => this.SetByKey(key, value);
    }
    ICollection<string> IDictionary<string, ICommonObject>.Keys => this.GetKeys();
    ICollection<ICommonObject> IDictionary<string, ICommonObject>.Values => this.GetValues();
    int ICollection<KeyValuePair<string, ICommonObject>>.Count => this.GetCount();
    bool ICollection<KeyValuePair<string, ICommonObject>>.IsReadOnly => this.GetIsReadOnly();
    void IDictionary<string, ICommonObject>.Add(string key, ICommonObject value) => this.Add(key, value);
    void ICollection<KeyValuePair<string, ICommonObject>>.Add(KeyValuePair<string, ICommonObject> item) => this.Add(item);
    void ICollection<KeyValuePair<string, ICommonObject>>.Clear() => this.Clear();
    bool ICollection<KeyValuePair<string, ICommonObject>>.Contains(KeyValuePair<string, ICommonObject> item) => this.Contains(item);
    bool IDictionary<string, ICommonObject>.ContainsKey(string key) => this.ContainsKey(key);
    void ICollection<KeyValuePair<string, ICommonObject>>.CopyTo(KeyValuePair<string, ICommonObject>[] array, int arrayIndex) => this.CopyTo(array, arrayIndex);
    IEnumerator<KeyValuePair<string, ICommonObject>> IEnumerable<KeyValuePair<string, ICommonObject>>.GetEnumerator() => this.GetPairEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    bool IDictionary<string, ICommonObject>.Remove(string key) => this.Remove(key);
    bool ICollection<KeyValuePair<string, ICommonObject>>.Remove(KeyValuePair<string, ICommonObject> item) => this.Remove(item);
    bool IDictionary<string, ICommonObject>.TryGetValue(string key, out ICommonObject value) => this.TryGetValue(key, out value);
    public ICommonObject GetByKey(string key) => ICommonObject.GET_BY_KEY(this, key);
    public void SetByKey(string key, ICommonObject value) => ICommonObject.SET_BY_KEY(this, key, value);
    public ICollection<string> GetKeys() => ICommonObject.GET_KEYS(this);
    public ICollection<ICommonObject> GetValues() => ICommonObject.GET_VALUES(this);
    public int GetCount() => ICommonObject.GET_COUNT(this);
    public bool GetIsReadOnly() => ICommonObject.GET_IS_READ_ONLY(this);
    public void Add(string key, ICommonObject value) => ICommonObject.ADD(this, key, value);
    public void Add(KeyValuePair<string, ICommonObject> item) => ICommonObject.ADD(this, item);
    new public void Clear() => ICommonObject.CLEAR(this);
    public bool Contains(KeyValuePair<string, ICommonObject> item) => ICommonObject.CONTAINS(this, item);
    new public bool ContainsKey(string key) => ICommonObject.CONTAINS_KEY(this, key);
    public void CopyTo(KeyValuePair<string, ICommonObject>[] array, int arrayIndex) => ICommonObject.COPY_TO(this, array, arrayIndex);
    public IEnumerator<KeyValuePair<string, ICommonObject>> GetPairEnumerator() => ICommonObject.GET_PAIR_ENUMERATOR(this);
    new public IEnumerator GetEnumerator() => ICommonObject.GET_ENUMERATOR(this);
    new public bool Remove(string key) => ICommonObject.REMOVE(this, key);
    public bool Remove(KeyValuePair<string, ICommonObject> item) => ICommonObject.REMOVE(this, item);
    public bool TryGetValue(string key, out ICommonObject value) => ICommonObject.TRY_GET_VALUE(this, key, out value);
}
