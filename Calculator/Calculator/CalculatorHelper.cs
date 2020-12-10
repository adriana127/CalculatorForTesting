using System;
using System.Collections.Generic;
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
        Calculator calculator=new Calculator();
        public List<char> Operators { get => operators; set => operators = value; }
        public List<double> Numbers { get => numbers; set => numbers = value; }
        public bool FirstNumberIsNegative { get => firstNumberIsNegative; set => firstNumberIsNegative = value; }
       

        public void VerifyFirstNumberSign(String input)
        {

           FirstNumberIsNegative = input[0].Equals('-');

        }
        public void ValidateInput(String input)
        {
            Regex objExpressionPattern = new Regex(@"^-?\d+(\s*[-+*/]\s*\d+)+$");
            if (!objExpressionPattern.IsMatch(input))
                throw new Exception("Invalid input format!");
        }
        public void CreateOperatorsList(String input)
        {
            foreach (char character in input)
            {
                if (!char.IsDigit(character) && character != ',' && character != '.')
                    Operators.Add(character);
            }
        }
        public void CreateNumbersList(String[] input)
        {
            if (FirstNumberIsNegative == true)
            {
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i].Contains(","))
                    {
                        string newstr = input[i].Replace(',', '.');
                        Numbers.Add(double.Parse(newstr));
                    }
                    else
                        Numbers.Add(double.Parse(input[i]));
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

                            Console.WriteLine(input[i]);
                        
                        Numbers.Add(aux);
                    }
                }
            }
            if (Numbers.Count==1)
            {
                throw new Exception("Invalid number of operands.");
            }
        }
        public void VerifyNumberOfOperators()
        {
            if (Operators.Count == Numbers.Count)
                Operators.Remove(Operators.ElementAt(Operators.Count - 1));
        }

        public void ReadFromFile()
        {
            string input = System.IO.File.ReadAllText(@"C:\Users\Adriana\Desktop\CalculatorForTesting\Calculator\Calculator\File.txt");
            try
            {
               // ValidateInput(input);
               
                VerifyFirstNumberSign(input);

                CreateOperatorsList(input);

                CreateNumbersList(input.Split(new char[] { '-', '+', '/', '*' }));

                VerifyNumberOfOperators();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public bool IsMultiplication(char operation)
        {
            if (operation.Equals('*') )
                return true;
            return false;
        }
        public bool IsAdd(char operation)
        {
            if (operation.Equals('+'))
                return true;
            return false;
        }

        public void Calculate()
        {
            while(Numbers.Count>1)// cata vreme am mai mult de 2 nr pe care pot face operatii
            {
                if(Operators.Contains('*')|| (Operators.Contains('/'))) //verific sa vad daca mai exista */ in operatori
                for(int i=0;i< Operators.Count;i++)
                {// daca da il caut
                 // cand am gasit operatia de grad una o execut si dau break
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
                else
                {
                    for (int i = 0; i < Operators.Count; i++)
                    {// daca da il caut
                        
                            // cand am gasit operatia de grad una o execut si dau break
                            if (IsAdd(Operators.ElementAt(i)))
                            Numbers[i] = calculator.Add(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));
                            else
                            Numbers[i] = calculator.Substraction(Numbers.ElementAt(i), Numbers.ElementAt(i + 1));
                        Numbers.Remove(Numbers.ElementAt(i + 1));
                        Operators.Remove(Operators.ElementAt(i));
                        break;
                        
                    }
                }
            }
            
        }
        public double GetResult()
        {
            return Numbers.ElementAt(0);
        }
    }
}
