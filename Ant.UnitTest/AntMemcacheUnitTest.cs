using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ant.Memcache.Test
{
    using Ant.UnitTest;

    /// <summary>
    /// AntMemcacheUnitTest 的摘要说明
    /// </summary>
    [TestClass]
    public class AntMemcacheUnitTest
    {
        public AntMemcacheUnitTest()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
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

        readonly MemcacheHelper helper = MemcacheHelper.Instance;

        [TestMethod]
        public void StringCache()
        {
            string testStr = "Hello World";
            this.helper.Set("TestStr", testStr);

            string result = this.helper.Get<string>("TestStr");
            AntAssert.AreEqual(testStr, result, string.Format("测试结果与预期值不符合。测试结果：{0},预期值：{1}", testStr, result));
            Assert.AreEqual(testStr, result);
        }

        [TestMethod]
        public void ObjectCache()
        {
            var model = new TestModel() { Id = 101, Name = "TestName" };
            this.helper.Set("TestObject",model);
            TestModel result = this.helper.Get<TestModel>("TestObject");
            Assert.AreEqual(model, result);
        }

        [TestMethod]
        public void BigDataCache()
        {
            int length = 80000;
            List<TestModel> list = new List<TestModel>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new TestModel()
                             {
                                 Id = i,
                                 Name = "TestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestNameTestName" + i,
                             });
            }
            this.helper.Set("BigData",list);
            var result = this.helper.Get<List<TestModel>>("BigData");
            Assert.AreEqual(length, result.Count);
        }
    }

    [Serializable]
    public class TestModel  
    {
        protected bool Equals(TestModel other)
        {
            return this.Id == other.Id && string.Equals(this.Name, other.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Id * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((TestModel)obj);
        }
    }
}
