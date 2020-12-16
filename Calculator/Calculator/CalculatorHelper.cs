using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorHelper
    {
        List<char> operators = new List<char>();
        List<double> numbers = new List<double>();
        bool firstNumberIsNegative = false;
        public List<char> Operators { get => operators; set => operators = value; }
        public List<double> Numbers { get => numbers; set => numbers = value; }
        public bool FirstNumberIsNegative { get => firstNumberIsNegative; set => firstNumberIsNegative = value; }

        public void VerifyFirstNumberSign(String input) //Adriana
        {
           FirstNumberIsNegative = input[0].Equals('-');
        }
        public void ValidateInput(String input) //Lorena
        {
            Regex objExpressionPattern = new Regex(@"^-?\d+(\s*[-+*/]\s*\d+)+$");
            if (!objExpressionPattern.IsMatch(input))
                throw new Exception("Invalid input format!");
        }
        public void CreateOperatorsList(String input)  //Lorena
        {
            foreach (char character in input)
            {
                if (!char.IsDigit(character) && character != ',' && character != '.')
                    Operators.Add(character);
            }
        }
        public void CreateNumbersList(String[] input) //Adriana
        {
            if (FirstNumberIsNegative == true)
            {
                int firstNumber = -1;
                for (int i = 1; i < input.Length; i++)
                {
                    if (i != 1) firstNumber = 1;
                    if (input[i].Contains(","))
                    {
                        string reformatedNumber = input[i].Replace(',', '.');
                        Numbers.Add(double.Parse(reformatedNumber)*firstNumber);
                    }
                    else
                        Numbers.Add(double.Parse(input[i])*firstNumber);
                }
                Operators.Remove(Operators.ElementAt(0));
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Contains(","))
                    {
                        string newstr = input[i].Replace(',', '.');
                        Numbers.Add(double.Parse(newstr));
                    }
                    else
                    {
                        double aux = double.Parse(input[i]);
                        Numbers.Add(aux);
                    }
                }
            }
            if (Numbers.Count==1)
            {
                throw new Exception("Invalid number of operands.");
            }
        }
        public void VerifyNumberOfOperators() //Lorena
        {
            if (Operators.Count == Numbers.Count)
                Operators.Remove(Operators.ElementAt(Operators.Count - 1));
        }
        public CalculatorHelper(String fileName) //Adriana
        {
            try
            {
                //ValidateInput(ReadFromFile(fileName));

                VerifyFirstNumberSign(ReadFromFile(fileName));

                CreateOperatorsList(ReadFromFile(fileName));

                CreateNumbersList(ReadFromFile(fileName).Split(new char[] { '-', '+', '/', '*' }));

                VerifyNumberOfOperators();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string ReadFromFile(String fileName) //Lorena
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("File not found.");
            return System.IO.File.ReadAllText(fileName);
        }
        public bool IsMultiplication(char operation) //Lorena
        {
            if (operation.Equals('*') )
                return true;
            return false;
        }
        public bool IsAdd(char operation)//Adriana
        {
            if (operation.Equals('+'))
                return true;
            return false;
        }
        public void TreatMultiplicationCase(Calculator calculator)//Lorena
        {
            for (int i = 0; i < Operators.Count; i++)
            {
                if (Operators.ElementAt(i).Equals('*') || (Operators.ElementAt(i).Equals('/')))
                {
                    if (IsMultiplication(Operators.ElementAt(i)))
                        Numbers[i] = calculator.Multiply(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));

                    else
                        Numbers[i] = calculator.Divide(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));
                    Numbers.Remove(Numbers.ElementAt(i + 1));
                    Operators.Remove(Operators.ElementAt(i));
                    break;
                }
            }
        }
        public void TreatAddCase(Calculator calculator)//Adriana
        {
            for (int i = 0; i < Operators.Count; i++)
            {
                if (IsAdd(Operators.ElementAt(i)))
                    Numbers[i] = calculator.Add(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));
                else
                    Numbers[i] = calculator.Substraction(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));
                Numbers.Remove(Numbers.ElementAt(i + 1));
                Operators.Remove(Operators.ElementAt(i));
                break;

            }
        }
        public void Calculate(Calculator calculator) //Lorena+Adriana
        {
            while(Numbers.Count>1)
            {
                if (Operators.Contains('*') || (Operators.Contains('/')))
                    TreatMultiplicationCase(calculator);
                else
                    TreatAddCase(calculator);
            }
        }
        public double GetResult()//Lorena+Adriana
        {
            return Numbers.ElementAt(0);
        }
    }
}
