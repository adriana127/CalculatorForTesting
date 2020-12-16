using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CalculatorHelper calculatorHelper = new CalculatorHelper(@"C:\Users\Adriana\Desktop\CalculatorForTesting\Calculator\Calculator\File.txt");
                Calculator calculator = new Calculator();

                Console.WriteLine(calculatorHelper.Operators.Count);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
