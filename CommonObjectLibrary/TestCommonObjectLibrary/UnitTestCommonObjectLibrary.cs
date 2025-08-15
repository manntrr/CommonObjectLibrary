namespace TestCommonObjectLibrary;

using CommonObjectLibrary;

public class UnitTestCommonObjectLibrary
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCommonObjectLibrary()
    {
        CommonObject commonObject = new();
        Assert.Pass();
    }
}
