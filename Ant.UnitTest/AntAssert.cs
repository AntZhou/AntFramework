namespace Ant.UnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class AntAssert
    {
        public static void AreEqual<T>(T expected, T actual,string message)
        {
            if (expected.Equals(actual))
            {
                
            }
            Assert.AreEqual(expected, actual, message);
        }
    }
}