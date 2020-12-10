using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class Tests
    {
        private Calculator.Calculator calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new Calculator.Calculator();
        } 

        [TestMethod]
        public void AddOperationShouldWorkProperly()
        {
            //Act
            var result = calculator.Add(2.3, 5.4);

            //Assert
            Assert.AreEqual(7.7, result);
        }
    }
}
