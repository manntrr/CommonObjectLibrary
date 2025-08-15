namespace TestCommonObjectLibrary;

public interface IObjectInterfaceTests
{
    [SetUp]
    public void Setup();
    [Test]
    public void TestStaticGetByKey();
    [Test]
    public void TestStaticSetByKey();
    [Test]
    public void TestStaticGetKeys();
    [Test]
    public void TestStaticGetValues();
    [Test]
    public void TestStaticGetCount();
    [Test]
    public void TestStaticGetIsReadOnly();
    [Test]
    public void TestStaticAddElements();
    [Test]
    public void TestStaticAddPair();
    [Test]
    public void TestStaticClear();
    [Test]
    public void TestStaticContains();
    [Test]
    public void TestStaticContainsKey();
    [Test]
    public void TestStaticCopyTo();
    [Test]
    public void TestStaticPairEnumerator();
    [Test]
    public void TestStaticEnumerator();
    [Test]
    public void TestStaticRemove();
    [Test]
    public void TestStaticRemovePair();
    [Test]
    public void TestStaticTryGetValue();
    [Test]
    public void StaticNullInitializorTest();
    [Test]
    public void StaticInterfaceCopyInitializorTest();
    [Test]
    public void StaticCopyInitializorTest();
    [Test]
    public void StaticDictionaryInterfaceInitializorTest();
    [Test]
    public void StaticDictionaryInitializorTest();
    [Test]
    public void StaticKVPairInitializorTest();
    [Test]
    public void StaticKVPairArrayInitializorTest();
    [Test]
    public void StaticElementArraysInitializorTest();
    [Test]
    public void StaticValueArrayInitializorTest();
}