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
            CalculatorHelper calculatorHelper = new CalculatorHelper(@"C:\Users\Adriana\Desktop\CalculatorForTesting\Calculator\Calculator\File.txt");
            try
            {
                calculatorHelper.Calculate();
                Console.WriteLine(calculatorHelper.GetResult());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
