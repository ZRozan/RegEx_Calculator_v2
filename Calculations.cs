using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralTraining
{
    class Calculations
    {
        public static int StartCalculator(List<string> inputValuesList)
        {
            List<string> receivedValuesList = inputValuesList;
            List<string> valuesToCalculate = new List<string>();

            Calculations calculations = new Calculations();

            if (receivedValuesList.Count() < 2)
            {
                receivedValuesList.Add("+");
                receivedValuesList.Add("0");
            }

            do
            {
                for (int i = 0; i < 3; i++)
                {
                    valuesToCalculate.Add(receivedValuesList[i]);
                }

                int result = 0;
                string calcOperator = valuesToCalculate[1];
                int startingValue = Int32.Parse(valuesToCalculate[0]);
                int secondValue = Int32.Parse(valuesToCalculate[2]);

                switch (calcOperator)
                {
                    case "+":
                        calculations.Sum(startingValue, secondValue, out result);
                        break;
                    case "-":
                        calculations.Minus(startingValue, secondValue, out result);
                        break;
                    case "*":
                        calculations.Multiply(startingValue, secondValue, out result);
                        break;
                    case "/":
                        calculations.Division(startingValue, secondValue, out result);
                        break;
                }

                receivedValuesList[0] = result.ToString();
                receivedValuesList.RemoveAt(2);
                receivedValuesList.RemoveAt(1);
                valuesToCalculate.Clear();
            }
            while (receivedValuesList.Count() != 1);


            int finalResult = Int32.Parse(receivedValuesList[0]);
            return finalResult;

            //{
            //    do
            //    {
            //        Console.WriteLine($"#---- Current value: {finalResult}\n");

            //        Console.Write("Choose a calculation: +  -  *  /  'S'quare Root: ");
            //        string calculationSwitch = Console.ReadLine().ToUpper();

            //        switch (calculationSwitch)
            //        {
            //            case "+":
            //                calculations.Sum(currentResult, out currentResult);
            //                break;
            //            case "-":
            //                calculations.Minus(currentResult, out currentResult);
            //                break;
            //            case "*":
            //                calculations.Multiply(currentResult, out currentResult);
            //                break;
            //            case "/":
            //                calculations.Division(currentResult, out currentResult);
            //                break;
            //        }
            //        Console.WriteLine($"\nRESULT: {currentResult}");

            //        return 0; // return the result to the program
            //    }
            //    while (calculationsRunning = AnotherCalculationQuestion());
            //}
        }
        public void Sum(int firstNumber, int secondNumber, out int result)
        {
            result = firstNumber + secondNumber;
        }
        public void Minus(int firstNumber, int secondNumber, out int result)
        {
            result = firstNumber - secondNumber;
        }
        public void Multiply(int firstNumber, int secondNumber, out int result)
        {
            result = firstNumber * secondNumber;
        }
        public void Division(int firstNumber, int secondNumber, out int result)
        {
            result = firstNumber / secondNumber;
        }

        static bool AnotherCalculationQuestion()
        {
            Console.WriteLine("\n\t#---- Continue? (Y/N) ----#");
            string response = Console.ReadLine().ToUpper();

            switch (response)
            {
                case "Y":
                    Console.Clear();
                    Console.WriteLine("\n\t#---- All right, let's go! ----#\n");
                    return true;
                    break;
                case "N":
                    return false;
                    break;
                default:
                    Console.WriteLine("#-- There are only two options, c'mon... --#");
                    return AnotherCalculationQuestion();
                    break;
            }
        }
        static List<double> numbersToCalculate()
        {
            List<double> numbersList = new List<double>();
            double inputValue;
            bool checkInputValue;

            Console.WriteLine("\n\t#----    Press any letter for the result.   ----#");
            Console.WriteLine("\t#---- Write your values separated by Enter: ----#");

            do
            {
                checkInputValue = Double.TryParse(Console.ReadLine(), out inputValue);
                if (checkInputValue) { numbersList.Add(inputValue); }
            }
            while (checkInputValue);

            return numbersList;
        }

    }
}
