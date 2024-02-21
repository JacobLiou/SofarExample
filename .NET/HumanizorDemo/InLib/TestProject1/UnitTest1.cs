namespace TestProject1
{
    /// <summary>
    /// 单元测试中 方法的执行顺序是怎么样的
    /// 这对
    /// MSTest  NUnit XUnit 三个测试框架来说是不一样的
    /// </summary>
    [TestClass]
    public class ByAlphabeticalOrder
    {
        public static bool Test1Called;
        public static bool Test2Called;
        public static bool Test3Called;

        [TestMethod]
        public void Test2()
        {
            Test2Called = true;

            Assert.IsTrue(Test1Called);
            Assert.IsFalse(Test3Called);
        }

        [TestMethod]
        public void Test1()
        {
            Test1Called = true;

            Assert.IsFalse(Test2Called);
            Assert.IsFalse(Test3Called);
        }

        [TestMethod]
        public void Test3()
        {
            Test3Called = true;

            Assert.IsTrue(Test1Called);
            Assert.IsTrue(Test2Called);
        }
    }
}