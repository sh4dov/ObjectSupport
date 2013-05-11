using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.ExpressionNameStrategies;

namespace ObjectSupporter.UT.ExpressionNameStrategies
{
    [TestClass]
    public class MethodCallExpressionNameStrategyTest
    {
        private MethodCallExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new MethodCallExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleMethodCallExpression()
        {
            Expression<Action<TestClass>> expression = t => t.Method1();

            var canHandle = _strategy.CanHandle(expression.Body);

            Assert.IsTrue(canHandle);
        }

        [TestMethod]
        public void ShouldReturnMethodName()
        {
            Expression<Action<TestClass>> expression = t => t.Method1();

            var name = _strategy.GetName(expression.Body);

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