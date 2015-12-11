using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ant.UnitTest
{
    using Log4Net;

    /// <summary>
    /// AntLog4NetUnitTest 的摘要说明
    /// </summary>
    [TestClass]
    public class AntLog4NetUnitTest
    {
        public AntLog4NetUnitTest()
        {

        }

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext { get; set; }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void LogTest()
        {
            LogHelper.Debug(this, "Debug");
            LogHelper.Error(this, "Error");
            LogHelper.Fatal(this, "Fatal");
            LogHelper.Info(this, "Info");
            LogHelper.Warn(this, "Warn");
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void DbLogTest()
        {
            
        }
    }
}
