using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.IO;
using System.Collections.Generic;
using Moq;

namespace CalculatorTesting
{
    [TestClass]
    public class CalculatorHelperTests
    {
  
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [DataTestMethod]
        [DataRow("+")]
        [DataRow(".")]
        [DataRow("a")]
        [DataRow("1")]
        public void VerifyFirstNumberSign_ShouldReturnFalse(string input)
        {
            CalculatorHelper calculator = new CalculatorHelper();
            //Act

            calculator.VerifyFirstNumberSign(input);
            var result = calculator.FirstNumberIsNegative;
            //Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("-1")]
        [DataRow("-12+4")]
        [DataRow("-")]
        public void VerifyFirstNumberSign_ShouldReturnTrue(string input)
        {
            CalculatorHelper calculator = new CalculatorHelper();
            //Act

            calculator.VerifyFirstNumberSign(input);
            var result = calculator.FirstNumberIsNegative;
            //Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("-45+554-21", true)]
        [DataRow("- 1+2", true)]
        [DataRow(".33", false)]
        [DataRow("a455-342", false)]
        [DataRow("133+1", false)]
        [DataRow("-11+33", true)]

        public void VerifyFirstNumberSign_ShouldWorkProperly(string input, bool expected)
        {
            CalculatorHelper calculator = new CalculatorHelper();
            //Act

            calculator.VerifyFirstNumberSign(input);
            var result = calculator.FirstNumberIsNegative;
            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("- 1+ 2","-1+2")]
        [DataRow("- 1  + 2", "-1+2")]
        [DataRow(" - 1+ 2 ", "-1+2")]

        public void EliminateWhiteSpaces_ShouldWorkProperly(string input,string expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();
            //act
           
            var result = calculatorHelper.EliminateWhiteSpaces(input);
            //assert
            Assert.AreEqual(result,expected);
        }


        [DataTestMethod]
        [DataRow(new string[] { "1", "-24" }, new double[] { 1, -24 })]
        [DataRow(new string[] { "-23", "1", "31" }, new double[] { -23, 1, 31 })]
        [DataRow(new string[] { "12", "31", "1131" }, new double[] { 12, 31, 1131 })]
        [DataRow(new string[] { "-515", "53453", "534" }, new double[] { -515, 53453, 534 })]
        [DataRow(new string[] { "9", "1", "-2", "12", "238" }, new double[] { 9, 1, -2, 12, 238 })]
        [DataRow(new string[] { "-1", "53453", "534" }, new double[] { -1, 53453, 534 })]
        [DataRow(new string[] { "63", "12", "789" }, new double[] { 63, 12, 789 })]
        public void CreateNumberList_ShouldWorkProperly(string[] input, double[] expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();
            //act
            calculatorHelper.CreateNumbersList(input);
            var result = calculatorHelper.Numbers;
            //assert
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateNumberList_Throws_Exception()
        {
            //Arrange
            CalculatorHelper calculator = new CalculatorHelper();
            calculator.CreateNumbersList(new string[] { "1" });
        }

        [DataTestMethod]
        [DataRow('+', true)]
        [DataRow('-', false)]
        [DataRow('*', false)]
        [DataRow('x', false)]
        [DataRow('/', false)]

        public void IsAdd_ShouldWorkProperly(char input, bool expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();
            //act
            var result = calculatorHelper.IsAdd(input);
            //assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new double[]{ -12.4, 3 }, -9.4)]
        [DataRow(new double[] {8, 2 }, 10)]
        [DataRow(new double[] { 312,1}, 313)]
        [DataRow(new double[] { 2.45, 2 },4.45)]


        public void AddCase_ShouldReturnTrue(double[] numbers,double expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();

            Mock<Calculator.Calculator> mockCalculator = new Mock<Calculator.Calculator>();
            //act
            calculatorHelper.Numbers = new List<double>(numbers);
            calculatorHelper.Operators.Add('+');
            calculatorHelper.TreatAddCase(mockCalculator.Object);
            var result = calculatorHelper.GetResult();
            //assert
            Assert.IsTrue(expected==result,"Expected result is different from acctual result");
        }

        [DataTestMethod]
        [DataRow(new double[] { -12.4, 3 }, -9)]
        [DataRow(new double[] { 8, 2 }, 10.2)]
        [DataRow(new double[] { 312, 1 }, 123)]
        [DataRow(new double[] { 2.45, 2 }, 4.4555)]


        public void AddCase_ShouldWorkProperly(double[] numbers, double expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();

            Mock<Calculator.Calculator> mockCalculator = new Mock<Calculator.Calculator>();
            //act
            calculatorHelper.Numbers = new List<double>(numbers);
            calculatorHelper.Operators.Add('+');
            calculatorHelper.TreatAddCase(mockCalculator.Object);
            var result = calculatorHelper.GetResult();
            //assert
            Assert.IsFalse(expected==result);
        }

        [DataTestMethod]
        [DataRow(new double[] { -12.4, 3 },new char[] { '+'}, -9.4)]
        [DataRow(new double[] { 5,67,24,7,2 }, new char[] { '+','*','/','+' }, 236.71)]
        [DataRow(new double[] {1,1,1 }, new char[] { '+', '/'}, 2)]
        public void Calculate_ShouldWorkProperly(double[] numbers,char[] operators, double expected)
        {
            //create
            CalculatorHelper calculatorHelper = new CalculatorHelper();
            Mock<Calculator.Calculator> mockCalculator = new Mock<Calculator.Calculator>();
            //act
            calculatorHelper.Numbers = new List<double>(numbers);
            calculatorHelper.Operators = new List<char>(operators);

            calculatorHelper.Calculate(mockCalculator.Object);
            var result = calculatorHelper.GetResult();
            //assert
            Assert.AreEqual(Math.Round(expected,2), Math.Round(result,2));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Constructor_ReceivesNullFile_ThrowsArgumentNullException()
        {
            new CalculatorHelper(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadFromFile_Throws_FileNotFoundException()
        {
            //Arrange
            CalculatorHelper calculator = new CalculatorHelper();
            calculator.ReadFromFile(@"ggg");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadFromFile_Throws_ArgumentNullException()
        {
            //Arrange
            CalculatorHelper calculator = new CalculatorHelper();
            calculator.ReadFromFile(null);
        }
    }
}
