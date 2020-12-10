using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTesting
{
    [TestClass]
    public class UnitTest1
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
            var result = calculator.Add(2.5, 5.2);

            //Assert
            Assert.AreEqual(7.7, result);
        }

        [TestMethod]
        public void SubstractionOperationShouldWorkProperly()
        {
            //Act
            var result = calculator.Substraction(7.5, 2);

            //Assert
            Assert.AreEqual(5.5, result);
        }

        [TestMethod]
        public void DivideOperationShouldWorkProperly()
        {
            //Act
            var result = calculator.Divide(18, 2);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void MultiplyOperationShouldWorkProperly()
        {
            //Act
            var result = calculator.Multiply(7, 2);

            //Assert
            Assert.AreEqual(14, result);
        }

    }
}
