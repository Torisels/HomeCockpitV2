using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeCockpitV2;
namespace HomeCockpitV2UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Bit.IsBitSet(0b00110011, 0);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var result = Bit.IsBitSet(0b00110011, 2);
            Assert.IsFalse(result);
        }
    }
}
