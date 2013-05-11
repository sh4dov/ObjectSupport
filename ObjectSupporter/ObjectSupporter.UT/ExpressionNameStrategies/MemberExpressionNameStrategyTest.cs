using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSupporter.ExpressionNameStrategies;

namespace ObjectSupporter.UT.ExpressionNameStrategies
{
    [TestClass]
    public class MemberExpressionNameStrategyTest
    {
        private MemberExpressionNameStrategy _strategy;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new MemberExpressionNameStrategy();
        }

        [TestMethod]
        public void ShouldHandleMemberExpression()
        {
            object argument = null;
            Expression<Func<object>> expression = () => argument;

            var canHandle = _strategy.CanHandle(expression.Body);

            Assert.IsTrue(canHandle);
        }

        [TestMethod]
        public void ShouldReturnNullWhenGetNotSupportedExpressionType()
        {
            Expression<Func<object>> expression = () => null;

            var name = _strategy.GetName(expression);

            Assert.IsNull(name);
        }
    }
}