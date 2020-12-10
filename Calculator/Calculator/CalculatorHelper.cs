using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorHelper
    {

        public void ReadFromFile()
        {
            bool firstNumberIsNegative = false;
            string text = System.IO.File.ReadAllText(@"E:/PeoplePower/TestingCalculator/CalculatorForTesting/Calculator/Calculator/File.txt");

            if (text[0].Equals('-'))
            {
                firstNumberIsNegative = true;
            }

            string[] strings = text.Split(new char[] { '-', '+', '/', '*' });
            Queue<double> numbers = new Queue<double>();

            if (firstNumberIsNegative == true)
            {
                numbers.Enqueue(-double.Parse(strings[0]));
                for (int i = 1; i < strings.Length; i++)
                {
                    numbers.Enqueue(double.Parse(strings[i]));
                }
            }
            else
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    numbers.Enqueue(double.Parse(strings[i]));
                }
            }


        }
    }
}
