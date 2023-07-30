using System;
using System.Text;

namespace ReverseStringCasing
{
    class Program
    {
        private static void Main()
        {
            var input = GetInputString();
            var reversedCase = ReverseStringCasing(input);
            Console.WriteLine($"Reversed case: {reversedCase}");
        }

        private static string ReverseStringCasing(string inputText)
        {
            StringBuilder reversedCase = new();
            foreach (var character in inputText)
            {
                if (!char.IsLetter(character))
                    reversedCase.Append(character);
                else
                    reversedCase.Append(char.IsLower(character) ? char.ToUpper(character) : char.ToLower(character));
            }

            return reversedCase.ToString();
        }

        private static string GetInputString()
        {
            Console.WriteLine("Enter a Text:");
            return Console.ReadLine();
        }
    }
}