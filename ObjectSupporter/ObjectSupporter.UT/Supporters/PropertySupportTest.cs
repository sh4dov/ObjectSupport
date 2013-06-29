using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.Supporters;

namespace ObjectSupporter.UT.Supporters
{
    [TestClass]
    public class PropertySupportTest
    {
        private object _field;

        public object Property { get; set; }

        private static object StaticProperty { get; set; }

        private object PrivateProperty { get; set; }

        [TestMethod]
        public void PropertyShouldBeSet()
        {
            Assert.IsNotNull(ObjectSupport.Property);
        }

        [TestMethod]
        public void ShouldHandlePropertyOfClass()
        {
            var name = ObjectSupport.Property.GetName<TestClass, object>(c => c.Property);

            Assert.AreEqual("Property", name);
        }

        [TestMethod]
        public void ShouldHandleStaticProperty()
        {
            var name = ObjectSupport.Property.GetName(() => StaticProperty);

            Assert.AreEqual("StaticProperty", name);
        }

        [TestMethod]
        public void ShouldNotContainAnyPublicConstructors()
        {
            var constructors = typeof(PropertySupport).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            Assert.AreEqual(0, constructors.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleFields()
        {
            ObjectSupport.Property.GetName(() => _field);
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
        public void ShouldNotHandleMethods()
        {
            ObjectSupport.Property.GetName(() => Method());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotHandleVariables()
        {
            object variable = null;
            ObjectSupport.Property.GetName(() => variable);
        }

        [TestMethod]
        public void ShouldReturnNameOfTheLocalPrivateProperty()
        {
            string name = ObjectSupport.Property.GetName(() => PrivateProperty);

            Assert.AreEqual("PrivateProperty", name);
        }

        [TestMethod]
        public void ShouldReturnNameOfTheLocalProperty()
        {
            string name = ObjectSupport.Property.GetName(() => Property);

            Assert.AreEqual("Property", name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenExpressionIsNull()
        {
            ObjectSupport.Property.GetName<object>(null);
        }

        private object Method()
        {
            return null;
        }

        private void Method(object parameter)
        {
            ObjectSupport.Property.GetName(() => parameter);
        }

        private class TestClass
        {
            public object Property { get; set; }
        }
    }
}