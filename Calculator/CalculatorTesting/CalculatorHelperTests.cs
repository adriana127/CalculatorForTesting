using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTesting
{
    [TestClass]
    public class CalculatorHelperTests
    {
        
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void ConstructorShouldWorkProperly()
        {
            CalculatorHelper calculator = new CalculatorHelper(@"C:\Users\Adriana\Desktop\CalculatorForTesting\Calculator\Calculator\File.txt");
            //Act
            calculator.Calculate();
            var result = calculator.GetResult();

            //Assert
            Assert.AreEqual(-7.4, result);
        }

       

    }
}
