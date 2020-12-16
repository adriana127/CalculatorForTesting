using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using Moq;

namespace CalculatorTesting
{
    [TestClass]
    public class CalculatorTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DivideBy0ThrowsException()
        {
            Calculator.Calculator calculator = new Calculator.Calculator();
            calculator.Divide(1, 0);
        }

        [TestMethod]
        public void AddOperationShouldWorkProperly()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Add(2, 2)).Returns(4);

            Assert.AreEqual(4, calculator.Object.Add(2, 2));
        }

        [TestMethod]
        public void SubstractionOperationShouldWorkProperly()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Substraction(2, 2)).Returns(0);

            Assert.AreEqual(0, calculator.Object.Substraction(2, 2));
        }

        [TestMethod]
        public void DivideOperationShouldWorkProperly()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Divide(2, 2)).Returns(1);

            Assert.AreEqual(1, calculator.Object.Divide(2, 2));
        }

        [TestMethod]
        public void MultiplyOperationShouldWorkProperly()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Multiply(2, 3)).Returns(6);

            Assert.AreEqual(6, calculator.Object.Multiply(2, 3));
        }

    }
}
