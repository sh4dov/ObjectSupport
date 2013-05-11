using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.ExpressionNameStrategies;

namespace ObjectSupporter.UT.ExpressionNameStrategies
{
    [TestClass]
    public class BinaryExpressionNameStrategyTest
    {
        private BinaryExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new BinaryExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleBinaryExpression()
        {
            object argument = null;
            Expression<Func<bool>> expression = () => argument == null;

            var canHandle = _strategy.CanHandle(expression.Body);

            Assert.IsTrue(canHandle);
        }

        [TestMethod]
        public void ShouldReturnNameOfTheBinaryExpression()
        {
            object argument = null;
            Expression<Func<bool>> expression = () => argument == null;

            var name = _strategy.GetName(expression.Body);

            Assert.AreEqual("(value(ObjectSupporter.UT.ExpressionNameStrategies.BinaryExpressionNameStrategyTest+<>c__DisplayClass2).argument == null)", name);
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