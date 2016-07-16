using System;

namespace Calculator
{
    internal static class IO
    {
        internal static string ReadExpression()
        {
            var expression = string.Empty;
            while (string.IsNullOrEmpty(expression))
            {
                Console.WriteLine("Enter an expression in the following format: <number> <operator> <number>");
                Console.WriteLine("Where <number> is of type double, and <operator> is +, -, *, or /.");
                Console.WriteLine("Example: 79.45 / (-3)");
                expression = Console.ReadLine();
                Console.WriteLine();
            }
            return expression;
        }

        internal static void WriteDivideByZero()
        {
            Console.WriteLine("Error: Cannot divide by zero!");
            Console.WriteLine();
        }

        internal static void WriteLimitsViolation()
        {
            Console.WriteLine("Error: Calculation result exceeds the limits of type double!");
            Console.WriteLine();
        }

        internal static void WriteResult(double result)
        {
            Console.WriteLine($"The Calculation result is: {result}");
            Console.WriteLine();
        }
    }
}
