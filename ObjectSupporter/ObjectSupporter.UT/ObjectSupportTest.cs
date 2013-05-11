using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectSupporter.UT
{
    [TestClass]
    public class ObjectSupportTest
    {
        private object LocalProperty { get; set; }

        [TestMethod]
        public void ShouldReturnLocalMethodName()
        {
            var name = ObjectSupport.GetName(() => LocalMethod1());

            Assert.AreEqual("LocalMethod1", name);
        }

        [TestMethod]
        public void ShouldReturnLocalPropertyName()
        {
            var name = ObjectSupport.GetName(() => LocalProperty);

            Assert.AreEqual("LocalProperty", name);
        }

        [TestMethod]
        public void ShouldReturnMethodName()
        {
            var name = ObjectSupport.GetName<TestClass>(t => t.Method1());

            Assert.AreEqual("Method1", name);
        }

        [TestMethod]
        public void ShouldReturnPropertyName()
        {
            var name = ObjectSupport.GetName<TestClass>(t => t.Property1);

            Assert.AreEqual("Property1", name);
        }

        [TestMethod]
        public void ShouldReturnVariableName()
        {
            var variable = new object();

            var name = ObjectSupport.GetName(() => variable);

            Assert.AreEqual("variable", name);
        }

        [TestMethod]
        public void ShouldReturnConstantValueName()
        {
            var name = ObjectSupport.GetName(() => true);

            Assert.AreEqual("True", name);
        }

        [TestMethod]
        public void ShouldReturnNameFromExpression()
        {
            Expression<Func<object>> expression = () => LocalProperty;

            var name = ObjectSupport.GetName(expression.Body);

            Assert.AreEqual("LocalProperty", name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionWhenParameterIsNotSupported()
        {
            ObjectSupport.GetName((Expression)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenExpressionIsNull()
        {
            ObjectSupport.GetName((LambdaExpression)null);
        }

        private void LocalMethod1()
        {
        }

        private class TestClass
        {
            public object Property1 { get; private set; }

            public void Method1()
            {
            }
        }
    }
}