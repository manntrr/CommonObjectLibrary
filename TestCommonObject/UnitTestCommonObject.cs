// Ensure the correct using directive for the CommonObject namespace
namespace TestComonObject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        CommonObject commonObject = new CommonObject();
        Assert.Pass();
    }
}
