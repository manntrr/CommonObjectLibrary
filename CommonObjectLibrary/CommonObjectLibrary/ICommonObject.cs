using System.Collections;

using CommonObjectLibrary;
using CommonObject = CommonObjectLibrary.CommonObject;
using CommonObjectInterface = CommonObjectLibrary.ICommonObject;
using TestCasesDataDictionary = NUnit.Framework.TestCasesDataDictionary;
using UnitTestCommonObjectLibrary = TestCommonObjectLibrary.UnitTestCommonObjectLibrary;

namespace CommonObjectLibrary;

public interface ICommonObject : IDictionary<string, ICommonObject>
{
    bool isReadOnly { get; set; }
    ICollection<string> BaseKeys { get; }
    ICollection<CommonObject> BaseValues { get; }
    int BaseCount { get; }
    void BaseAdd(string key, CommonObject value);
    void BaseAdd(KeyValuePair<string, CommonObject> item);
    void BaseClear();
    bool BaseContains(KeyValuePair<string, CommonObject> item);
    bool BaseContainsKey(string key);
    void BaseCopyTo(KeyValuePair<string, CommonObject>[] array, int arrayIndex);
    IEnumerator<KeyValuePair<string, CommonObject>> BaseGetPairEnumerator();
    IEnumerator BaseGetEnumerator();
    bool BaseRemove(string key);
    bool BaseRemove(KeyValuePair<string, CommonObject> item);
    bool BaseTryGetValue(string key, out CommonObject value);
    public ICommonObject GetByKey(string key);
    public void SetByKey(string key, ICommonObject value);
    public ICollection<string> GetKeys();
    public ICollection<ICommonObject> GetValues();
    public int GetCount();
    public bool GetIsReadOnly();
    new public void Add(string key, ICommonObject value);
    new public void Add(KeyValuePair<string, ICommonObject> item);
    new public void Clear();
    new public bool Contains(KeyValuePair<string, ICommonObject> item);
    new public bool ContainsKey(string key);
    new public void CopyTo(KeyValuePair<string, ICommonObject>[] array, int arrayIndex);
    public IEnumerator<KeyValuePair<string, ICommonObject>> GetPairEnumerator();
    new public IEnumerator GetEnumerator();
    new public bool Remove(string key);
    new public bool Remove(KeyValuePair<string, ICommonObject> item);
    new public bool TryGetValue(string key, out ICommonObject value);

    public static ICommonObject GET_BY_KEY(ICommonObject _object, string key)
    {
        return _object[key];
    }
    public static void SET_BY_KEY(ICommonObject _object, string key, ICommonObject value)
    {
        _object[key] = value;
    }
    public static ICollection<string> GET_KEYS(ICommonObject _object)
    {
        return _object.BaseKeys;
    }
    public static ICollection<ICommonObject> GET_VALUES(ICommonObject _object)
    {
        return (ICollection<ICommonObject>)_object.BaseValues;
    }
    public static int GET_COUNT(ICommonObject _object)
    {
        return _object.BaseCount;
    }
    public static bool GET_IS_READ_ONLY(ICommonObject _object)
    {
        return _object.isReadOnly;
    }
    public static void ADD(ICommonObject _object, string key, ICommonObject value)
    {
        _object.BaseAdd(key, (CommonObject)value);
    }
    public static void ADD(ICommonObject _object, KeyValuePair<string, ICommonObject> item)
    {
        _object.BaseAdd(new KeyValuePair<string, CommonObject>(key: item.Key, value: (CommonObject)item.Value));
    }
    public static void CLEAR(ICommonObject _object)
    {
        _object.BaseClear();
    }
    public static bool CONTAINS(ICommonObject _object, KeyValuePair<string, ICommonObject> item)
    {
        return _object.BaseContains(new KeyValuePair<string, CommonObject>(key: item.Key, value: (CommonObject)item.Value));
    }
    public static bool CONTAINS_KEY(ICommonObject _object, string key)
    {
        return _object.BaseContainsKey(key);
    }
    public static void COPY_TO(ICommonObject _object, KeyValuePair<string, ICommonObject>[] array, int arrayIndex)
    {
        KeyValuePair<string, CommonObject>[] temp = new KeyValuePair<string, CommonObject>[array.Length];
        for (int i = 0; i < array.Length; i++) temp[i] = new(array[i].Key, (CommonObject)array[i].Value);
        _object.BaseCopyTo(temp, arrayIndex);
    }
    public static IEnumerator<KeyValuePair<string, ICommonObject>> GET_PAIR_ENUMERATOR(ICommonObject _object)
    {
        IEnumerator<KeyValuePair<string, CommonObject>> temp = _object.BaseGetPairEnumerator();
        List<KeyValuePair<string, ICommonObject>> result = [];
        while (temp.MoveNext())
            result.Add(new(temp.Current.Key, temp.Current.Value));
        return result.GetEnumerator();
    }
    public static IEnumerator GET_ENUMERATOR(ICommonObject _object)
    {
        return _object.BaseGetEnumerator();
    }
    public static bool REMOVE(ICommonObject _object, string key)
    {
        return _object.BaseRemove(key);
    }
    public static bool REMOVE(ICommonObject _object, KeyValuePair<string, ICommonObject> item)
    {
        return _object.BaseRemove(new KeyValuePair<string, CommonObject>(key: item.Key, value: (CommonObject)item.Value));
    }
    public static bool TRY_GET_VALUE(ICommonObject _object, string key, out ICommonObject value)
    {
        CommonObject temp;
        bool result = _object.BaseTryGetValue(key, out temp);
        value = temp;
        return result;
    }
    static readonly TestCasesDataDictionary TEST_CASE_DATA = new([
        /*new(nameof(UnitTestCommonObjectLibrary.NullConstructorTest), new(
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