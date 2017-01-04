namespace Ant.UnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class TestModel1
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Console.WriteLine("asda");
                this.name = value;
            }
        }
    }

    [TestClass]
    public class OtherTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = new TestModel1 { Name = "123" };
            model.Name = "12";
            var asd = "123" + model.Name;
        }
    }
}