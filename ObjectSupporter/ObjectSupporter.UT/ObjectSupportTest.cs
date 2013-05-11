using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectSupporter.UT
{
    [TestClass]
    public class ObjectSupportTest
    {
        [TestMethod]
        public void ShouldReturnMethodName()
        {
            var name = ObjectSupport.GetName<TestClass>(t => t.Method1());

            Assert.AreEqual("Method1", name);
        }

        private class TestClass
        {
            public void Method1()
            {
            }
        }
    }
}