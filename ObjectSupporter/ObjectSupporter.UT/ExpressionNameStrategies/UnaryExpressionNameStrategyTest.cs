using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.ExpressionNameStrategies;

namespace ObjectSupporter.UT.ExpressionNameStrategies
{
    [TestClass]
    public class UnaryExpressionNameStrategyTest
    {
        private UnaryExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new UnaryExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleUnaryExpression()
        {
            Expression<Func<object>> expression = () => true;
            var canHandle = _strategy.CanHandle(expression.Body);

            Assert.IsTrue(canHandle);
        }

        [TestMethod]
        public void ShouldReturnNameOfTheUnaryExpression()
        {
            Expression<Func<object>> expression = () => true;

            var name = _strategy.GetName(expression.Body);

            Assert.AreEqual("True", name);
        }

        [TestMethod]
        public void ShouldReturnNullWhenGetNotSupportedExpressionType()
        {
            object argument = null;
            Expression<Func<object>> expression = () => argument;

            var name = _strategy.GetName(expression);

            Assert.IsNull(name);
        }
    }
}