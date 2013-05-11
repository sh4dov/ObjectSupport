using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.ExpressionNameStrategies;

namespace ObjectSupporter.UT.ExpressionNameStrategies
{
    [TestClass]
    public class ConstantExpressionNameStrategyTest
    {
        private ConstantExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new ConstantExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleConstantExpression()
        {
            Expression<Func<object>> expression = () => null;

            var canHandle = _strategy.CanHandle(expression.Body);

            Assert.IsTrue(canHandle);
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