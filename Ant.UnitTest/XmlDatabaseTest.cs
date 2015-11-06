namespace Ant.UnitTest
{
    using System.Linq;

    using Ant.XmlDatabase;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class XmlDatabaseTest
    {
        [TestMethod]
        public void SaveObj()
        {
            var model = new TestModel { Id = 1, Name = "test", Number = "001" };
            XmlDatabaseHelper.Save(model);
        }

        [TestMethod]
        public void GetObj()
        {
            var list = XmlDatabaseHelper.Query<TestModel>();
        }

        [TestMethod]
        public void DeleteAll()
        {
            var list = XmlDatabaseHelper.Query<TestModel>();
            list.ToList().ForEach(XmlDatabaseHelper.Delete);
        }

        [TestMethod]
        public void Update()
        {
            var list = XmlDatabaseHelper.Query<TestModel>();
            var item = list.FirstOrDefault();
            item.Name += "1";
            XmlDatabaseHelper.Save(item);
        }
    }

    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }
    }
}