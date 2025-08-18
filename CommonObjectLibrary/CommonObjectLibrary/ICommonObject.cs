namespace CommonObjectLibrary;

using System.Collections;

using Object = CommonObject;
using ObjectInterface = ICommonObject;
using TCDD = /*NUnit.Framework./**/TestCaseDataDictionary;
using TCsDD = /*NUnit.Framework./**/TestCasesDataDictionary;
using COLTs = TestCommonObjectLibrary.ILibraryTests;

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
    }
    public static void INIT(ObjectInterface newObject, ObjectInterface originalObject)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, Object originalObject)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, IDictionary<string, System.Object> originalObject)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, Dictionary<string, System.Object> originalObject)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object> originalObject)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, KeyValuePair<string, System.Object>[] objects)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, string[] keys, System.Object[] objects)
    {
        throw new NotImplementedException();
    }
    public static void INIT(ObjectInterface newObject, System.Object[] objects)
    {
        throw new NotImplementedException();
    }
    static readonly TCsDD TEST_CASE_DATA = new([
        // TODO:  complete test case data
        /**/new(nameof(COLTs.GetByKeyFunctionTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.ConstructorString],
        TestCaseIds: [counter++.ToString()],
        TestCaseData: [
            new(
                //System.Object caseProvidedObject, string caseProvidedKey, System.Object caseExpectedValue
                new CommonObject(), "test", "test"
                )
        ]))/**//*,
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
    new(nameof(GenreTests.NullInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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
    new(nameof(GenreTests.KeyInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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
    new(nameof(GenreTests.NameInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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
    new(nameof(GenreTests.KeyNameInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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
    new(nameof(GenreTests.IndexInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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
    new(nameof(GenreTests.CopyInitializorTest), new(
        TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
        TestCaseCategories: [TCDD.InitializorString],
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