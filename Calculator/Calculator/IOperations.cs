using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IOperations
    {
        double Add(double number1, double number2);
        double Substraction(double number1, double number2);
        double Divide(double number1, double number2);
        double Multiply(double number1, double number2);
    }
}
