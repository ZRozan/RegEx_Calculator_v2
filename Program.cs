using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GeneralTraining
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> inputValuesList = CalculationInputs();
            int result = Calculations.StartCalculator(inputValuesList);
          
            Console.WriteLine();
            if (result == 69)
            {
                Console.WriteLine($"The result is: {result}. NICE!");
            }
            else
            {
                Console.WriteLine($"The result is: {result}");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        public static List<string> CalculationInputs()
        {
            string cleanupPattern = @"[^\d\+\-\*\/]";
            string separatorPattern = @"(\d+)|(\W)";
            Regex rxDigitOperator = new Regex(separatorPattern);
            string findStartEmptyNumber = @"(^\W\d+)";
            string addStartingZero = @"0$&";
            string findEndEmptyNumber = @"(\d+\W$)";
            string addEndingZero = @"$&0";
            string divisionByZero = @"(\/0)";

            List<string> listValues = new List<string>();

            Console.WriteLine();
            Console.Write($"Write a calculation here:  ");

            string rawInput = Console.ReadLine();
            string cleanInput = Regex.Replace(rawInput, cleanupPattern, "");
            cleanInput = Regex.Replace(cleanInput, findStartEmptyNumber, addStartingZero);
            cleanInput = Regex.Replace(cleanInput, findEndEmptyNumber, addEndingZero);

            if (Regex.IsMatch(cleanInput, divisionByZero)) 
            {
                Console.WriteLine();
                Console.WriteLine("You can not divide by zero. Let's ignore that.");
                Console.WriteLine();
                cleanInput = Regex.Replace(cleanInput, divisionByZero, "/1");
                Console.ReadKey();
            }

            MatchCollection matchDigits = rxDigitOperator.Matches(cleanInput);

            for (int i = 0; i < matchDigits.Count(); i++)
            {
                listValues.Add(matchDigits[i].ToString());
            }

            return listValues;
        }
    }
}
