using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.Extensions;

namespace ObjectSupporter.UT.Extensions
{
    [TestClass]
    public class GenericConverterExtensionTest
    {
        private interface IA
        {
        }

        private interface IB
        {
            IA A { get; }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConverterShouldNotBeNull()
        {
            var obj = new object();

            obj.Convert((Func<object, int>)null);
        }

        [TestMethod]
        public void ResultShouldBeNullWhenFirstConversionWillReturnNull()
        {
            var c1 = new C(new B1(new A1()));

            var a1 = c1.Convert(c => c.B as B2).Convert(b2 => b2.A as A1);

            Assert.IsNull(a1);
        }

        [TestMethod]
        public void ResultShouldBeNullWhenSecondConversionWillReturnNull()
        {
            var c1 = new C(new B1(new A1()));

            var a2 = c1.Convert(c => c.B as B1).Convert(b1 => b1.A as A2);

            Assert.IsNull(a2);
        }

        [TestMethod]
        public void ShouldBeAbleToConvertWithSuccessfullyTransitionalConversions()
        {
            var c1 = new C(new B1(new A1()));

            var a1 = c1.Convert(c => c.B as B1).Convert(b1 => b1.A as A1);

            Assert.IsNotNull(a1);
        }

        [TestMethod]
        public void ShouldReturnConvertedObjectWhenCanBeConverted()
        {
            var b = new B1(new A1());

            var a1 = b.Convert(o => o.A as A1);

            Assert.IsNotNull(a1);
        }

        [TestMethod]
        public void ShouldReturnDefaultValueWhenValueIsNullAndTargetTypeIsNotClass()
        {
            object obj = null;

            var result = obj.Convert(o => o is string);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnNullWhenCannotBeConverted()
        {
            var b1 = new B1(new A1());

            var a1 = b1.Convert(b => b.A as A2);

            Assert.IsNull(a1);
        }

        [TestMethod]
        public void ShouldReturnNullWhenValueIsNullAndTargetTypeIsClass()
        {
            object obj = null;

            var type = obj.Convert(o => o.GetType());

            Assert.IsNull(type);
        }

        private class A1 : IA
        {
        }

        private class A2 : IA
        {
        }

        private class B1 : IB
        {
            public B1(IA a)
            {
                A = a;
            }

            public IA A { get; private set; }
        }

        private class B2 : IB
        {
            public B2(IA a)
            {
                A = a;
            }

            public IA A { get; private set; }
        }

        private class C
        {
            public C(IB b)
            {
                B = b;
            }

            public IB B { get; private set; }
        }
    }
}