using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public double Add(double number1, double number2)
        {
            return (number1 + number2);
        }

        public double Divide(double number1, double number2)
        {
            if (number2 == 0)
                throw new Exception("Can't divide by zero");
            return (number1 / number2);
        }

        public double Multiply(double number1, double number2)
        {
            return (number1 * number2);
        }

        public double Substraction(double number1, double number2)
        {
            return (number1 - number2);
        }
    }
}
