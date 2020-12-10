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

            //Act
            var result = calculator.Add(2.5, 5.2);

            //Assert
            Assert.AreEqual(7.7, result);
        }

       

    }
}
