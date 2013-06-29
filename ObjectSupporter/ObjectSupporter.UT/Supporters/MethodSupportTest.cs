using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.Supporters;

namespace ObjectSupporter.UT.Supporters
{
    [TestClass]
    public class MethodSupportTest
    {
        private object _field;

        public object Property { get; set; }

        private static object StaticProperty { get; set; }

        private object PrivateProperty { get; set; }

        [TestMethod]
        public void MethodShouldBeSet()
        {
            Assert.IsNotNull(ObjectSupport.Method);
        }

        [TestMethod]
        public void ShouldHandleMethodOfClass()
        {
            var name = ObjectSupport.Method.GetName<TestClass, Action>(c => c.Method1);

            Assert.AreEqual("Method1", name);
        }

        [TestMethod]
        public void ShouldHandleMethods()
        {
            var name = ObjectSupport.Method.GetName(() => Method1());

            Assert.AreEqual("Method1", name);
        }

        [TestMethod]
        public void ShouldHandleMethodsAsDelegates()
        {
            var name = ObjectSupport.Method.GetName<MethodSupportTest, Func<object>>(c => c.Method1);

            Assert.AreEqual("Method1", name);
        }

        [TestMethod]
        public void ShouldHandleMethodsWithParametersAsDelegates()
        {
            var name = ObjectSupport.Method.GetName<MethodSupportTest, Func<int, object, double>>(c => c.Method2);

            Assert.AreEqual("Method2", name);
        }

        [TestMethod]
        public void ShouldHandleMethodWithParametersOfClass()
        {
            var name = ObjectSupport.Method.GetName<TestClass, Func<int, object, double>>(c => c.Method2);

            Assert.AreEqual("Method2", name);
        }

        [TestMethod]
        public void ShouldNotContainAnyPublicConstructors()
        {
            var constructors = typeof(MethodSupport).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            Assert.AreEqual(0, constructors.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleFields()
        {
            ObjectSupport.Method.GetName(() => _field);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleFieldsOfTheClass()
        {
            ObjectSupport.Method.GetName<TestClass, object>(c => c._field);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleLocalPrivateProperty()
        {
            ObjectSupport.Method.GetName(() => PrivateProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleLocalProperty()
        {
            ObjectSupport.Method.GetName(() => Property);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleMethodParameter()
        {
            var parameter = new object();
            Method(parameter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandlePropertyOfClass()
        {
            ObjectSupport.Method.GetName<TestClass, object>(c => c.Property);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleStaticProperty()
        {
            ObjectSupport.Method.GetName(() => StaticProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleVariables()
        {
            object variable = null;
            ObjectSupport.Method.GetName(() => variable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenExpressionIsNull()
        {
            ObjectSupport.Method.GetName<object>(null);
        }

        private void Method(object parameter)
        {
            var name = ObjectSupport.Method.GetName(() => parameter);

            Assert.AreEqual("parameter", name);
        }

        private object Method1()
        {
            return null;
        }

        private double Method2(int i, object o)
        {
            return 0;
        }

        private class TestClass
        {
            internal object _field;

            public object Property { get; set; }

            public void Method1()
            {
            }

            public double Method2(int i, object o)
            {
                return 0;
            }
        }
    }
}