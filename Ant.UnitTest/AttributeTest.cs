#define Buged
namespace Ant.UnitTest
{
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void TestMethod()
        {
            ToolKit.FunA();
            ToolKit.FunB();
            ToolKit.FunC();
            ToolKit.FunD();

        }
    }

    internal class ToolKit
    {
        [Conditional("Li")] // Attribute名称的长记法
        [Conditional("Buged")]
        public static void FunA()
        {
            Debug.WriteLine("Created By Li, Buged.");
        }

        [Conditional("Li")] // Attribute名称的短记法
        [Conditional("NoBug")]
        public static void FunB()
        {
            Debug.WriteLine("Created By Li, NoBug.");
        }

        [Conditional("Zhang")] // Attribute名称的长记法
        [Conditional("Buged")]
        public static void FunC()
        {
            Debug.WriteLine("Created By Zhang, Buged.");
        }

        [Conditional("Zhang")] // Attribute名称的短记法
        [Conditional("NoBug")]
        public static void FunD()
        {
            Debug.WriteLine("Created By Zhang, NoBug.");
        }
    }
}