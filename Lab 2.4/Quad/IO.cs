using System;

namespace Quad
{
    internal static class IO
    {
        private static double ReadCoefficient(char name)
        {
            double coefficient;
            var input = string.Empty;
            while (!double.TryParse(input, out coefficient))
            {
                Console.Write($"{name} = ");
                input = Console.ReadLine();
            }
            return coefficient;
        }

        internal static void ReadCoefficients(Equation equation)
        {
            Console.WriteLine("Enter coefficients a, b, and c to the quadratic equation a*x^2+b*x+c=0.");
            Console.WriteLine("The coefficients are of type double.");
            equation.A = ReadCoefficient('a');
            equation.B = ReadCoefficient('b');
            equation.C = ReadCoefficient('c');
        }

        internal static void WriteSolution(Equation equation)
        {
            Console.WriteLine();
            if (equation.LimitsViolation)
            {
                Console.WriteLine("Error: Calculation result exceeds the limits of type double!");
                return;
            }
            if (equation.NumberOfSolutions < 0)
            {
                Console.WriteLine($"{equation.C} = 0 is false :(");
                return;
            }
            if (equation.NumberOfSolutions == 0)
            {
                Console.WriteLine(
                    $"The quadratic equation {equation.A}*x^2+{equation.B}*x+{equation.C}=0 has no real roots.");
                return;
            }
            if (equation.NumberOfSolutions == 1)
            {
                Console.WriteLine($"x = {equation.X1}");
                return;
            }
            if (equation.NumberOfSolutions == 2)
            {
                Console.WriteLine(
                    $"The 1st root of quadratic equation {equation.A}*x^2+{equation.B}*x+{equation.C}=0 is: {equation.X1}");
                Console.WriteLine(
                    $"The 2nd root of quadratic equation {equation.A}*x^2+{equation.B}*x+{equation.C}=0 is: {equation.X2}");
                return;
            }
            Console.WriteLine("0 = 0 is true :)");
        }
    }
}
