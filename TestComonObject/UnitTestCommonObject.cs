// Ensure the correct using directive for the CommonObject namespace
using CommonObject;

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
        CommonObject.CommonObject commonObject = new CommonObject.CommonObject();
        Assert.Pass();
    }
}
