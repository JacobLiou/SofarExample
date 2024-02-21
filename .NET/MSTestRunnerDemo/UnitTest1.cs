namespace MSTestRunnerDemo;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        bool result = true;
        Assert.AreEqual(result, false);
    }
}