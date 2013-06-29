using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.Supporters;

namespace ObjectSupporter.UT.Supporters
{
    [TestClass]
    public class FieldSupportTest
    {
        private object _field;

        public object Property { get; set; }

        private static object StaticProperty { get; set; }

        private object PrivateProperty { get; set; }

        [TestMethod]
        public void FieldShouldBeSet()
        {
            Assert.IsNotNull(ObjectSupport.Field);
        }

        [TestMethod]
        public void ShouldHandleFields()
        {
            var name = ObjectSupport.Field.GetName(() => _field);

            Assert.AreEqual("_field", name);
        }

        [TestMethod]
        public void ShouldHandleFieldsOfTheClass()
        {
            var name = ObjectSupport.Field.GetName<TestClass, object>(c => c._field);

            Assert.AreEqual("_field", name);
        }

        [TestMethod]
        public void ShouldHandleMethodParameter()
        {
            var parameter = new object();
            Method(parameter);
        }

        [TestMethod]
        public void ShouldHandleVariables()
        {
            object variable = null;
            var name = ObjectSupport.Field.GetName(() => variable);

            Assert.AreEqual("variable", name);
        }

        [TestMethod]
        public void ShouldNotContainAnyPublicConstructors()
        {
            var constructors = typeof(FieldSupport).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            Assert.AreEqual(0, constructors.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleLocalPrivateProperty()
        {
            ObjectSupport.Field.GetName(() => PrivateProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleLocalProperty()
        {
            ObjectSupport.Field.GetName(() => Property);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleMethods()
        {
            ObjectSupport.Field.GetName(() => Method());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleMethodsAsDelegates()
        {
            ObjectSupport.Field.GetName<Func<object>>(() => Method);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandlePropertyOfClass()
        {
            ObjectSupport.Field.GetName<TestClass, object>(c => c.Property);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleStaticProperty()
        {
            ObjectSupport.Field.GetName(() => StaticProperty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenExpressionIsNull()
        {
            ObjectSupport.Field.GetName<object>(null);
        }

        private object Method()
        {
            return null;
        }

        private void Method(object parameter)
        {
            var name = ObjectSupport.Field.GetName(() => parameter);

            Assert.AreEqual("parameter", name);
        }

        private class TestClass
        {
            internal object _field;

            public object Property { get; set; }
        }
    }
}