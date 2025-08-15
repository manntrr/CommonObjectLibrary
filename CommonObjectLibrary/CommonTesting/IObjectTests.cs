namespace TestCommonObjectLibrary;

public interface IObjectTests
{
    [SetUp]
    public void Setup();
    [Test]
    public void TestGetByKey();
    [Test]
    public void TestSetByKey();
    [Test]
    public void TestGetKeys();
    [Test]
    public void TestGetValues();
    [Test]
    public void TestGetCount();
    [Test]
    public void TestGetIsReadOnly();
    [Test]
    public void TestAddElements();
    [Test]
    public void TestAddPair();
    [Test]
    public void TestClear();
    [Test]
    public void TestContains();
    [Test]
    public void TestContainsKey();
    [Test]
    public void TestCopyTo();
    [Test]
    public void TestPairEnumerator();
    [Test]
    public void TestEnumerator();
    [Test]
    public void TestRemove();
    [Test]
    public void TestRemovePair();
    [Test]
    public void TestTryGetValue();
    [Test]
    public void NullConstructorTest();
    [Test]
    public void NullInitializorTest();
    [Test]
    public void InterfaceCopyConstructorTest();
    [Test]
    public void InterfaceCopyInitializorTest();
    [Test]
    public void CopyConstructorTest();
    [Test]
    public void CopyInitializorTest();
    [Test]
    public void DictionaryInterfaceConstructorTest();
    [Test]
    public void DictionaryInterfaceInitializorTest();
    [Test]
    public void DictionaryConstructorTest();
    [Test]
    public void DictionaryInitializorTest();
    [Test]
    public void KVPairConstructorTest();
    [Test]
    public void KVPairInitializorTest();
    [Test]
    public void KVPairArrayConstructorTest();
    [Test]
    public void KVPairArrayInitializorTest();
    [Test]
    public void ElementArraysConstructorTest();
    [Test]
    public void ElementArraysInitializorTest();
    [Test]
    public void ValueArrayConstructorTest();
    [Test]
    public void ValueArrayInitializorTest();
}