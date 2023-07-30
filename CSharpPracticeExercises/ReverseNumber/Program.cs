using System;
using System.Text;

namespace ReverseNumber
{
    class Program
    {
        private static void Main()
        {
            var inputNumber = GetValidInputNumber();
            
            ShowResult(inputNumber, Reverse(inputNumber));
            ShowResult(inputNumber, ReverseUsingMath(inputNumber));
           
            Console.ReadKey();
        }

        private static int GetValidInputNumber()
        {
            int inputNumber;
            string inputString;

            do
            {
                Console.WriteLine("Enter a Number:");
                inputString = Console.ReadLine();
            } while (!int.TryParse(inputString, out inputNumber) || string.IsNullOrWhiteSpace(inputString));

            return inputNumber;
        }

        private static int? Reverse(int inputNumber)
        {
            var absoluteNumber = Math.Abs(inputNumber);
            var stringNumber = absoluteNumber.ToString();
            StringBuilder reversedString = new();

            for (var currentIndex = stringNumber.Length - 1; currentIndex >= 0; currentIndex--)
            {
                reversedString.Append(stringNumber[currentIndex]);
            }

            if (!int.TryParse(reversedString.ToString(), out var reversedNumber))
                return null;

            return (inputNumber < 0) ? (reversedNumber * -1) : reversedNumber;
        }

        private static int? ReverseUsingMath(int inputNumber)
        {
            int? resultNumber = 0;
            do
            {
                var remainingBy10 = inputNumber / 10;
                try
                {
                    resultNumber = checked(resultNumber + CalculateMultiplier(inputNumber % 10, remainingBy10));
                }
                catch
                {
                    resultNumber = null;
                    break;
                }

                inputNumber = remainingBy10;
            } while (inputNumber != 0);

            return resultNumber;
        }

        private static int? CalculateMultiplier(int module, int remaining)
        {
            var power = 0;
            while (remaining != 0)
            {
                power++;
                remaining /= 10;
            }

            int? result = null;
            try
            {
                result = checked(module * (int)Math.Pow(10, power));
            }
            catch
            {
                throw new OverflowException();
            }


            return result;
        }

        private static void ShowResult(int input, int? result)
        {
            if (result == null)
                Console.WriteLine("Result is out of integer scope");
            else
                Console.WriteLine($"Input: {input.ToString()}. Reversed: {result.ToString()}");
        }
    }
}