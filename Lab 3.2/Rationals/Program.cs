using System;

namespace Rationals
{
    internal class Program
    {
        private static void Main()
        {
            var rational1 = new Rational(0);
            Console.WriteLine($"rational1 = {rational1}");
            Console.WriteLine($"rational1 = {rational1.Value}");
            var rational2 = new Rational(0, 0);
            Console.WriteLine($"rational2 = {rational2}");
            Console.WriteLine($"rational2 = {rational2.Value}");
            var rational3 = new Rational(1, 0);
            Console.WriteLine($"rational3 = {rational3}");
            Console.WriteLine($"rational3 = {rational3.Value}");
            var rational4 = new Rational(1);
            Console.WriteLine($"rational4 = {rational4}");
            Console.WriteLine($"rational4 = {rational4.Value}");
            var rational5 = new Rational(1, 2);
            Console.WriteLine($"rational5 = {rational5}");
            Console.WriteLine($"rational5 = {rational5.Value}");
            var rational6 = new Rational(3, 9);
            Console.WriteLine($"rational6 = {rational6}");
            Console.WriteLine($"rational6 = {rational6.Value}");
            var rational7 = new Rational(9, 27);
            Console.WriteLine($"rational7 = {rational7}");
            Console.WriteLine($"rational7 = {rational7.Value}");

            Console.WriteLine($"rational5 == Rational6 is {rational5.Equals(rational6)}");
            Console.WriteLine($"rational6 == rational7 is {rational6.Equals(rational7)}");

            Console.WriteLine($"rational5 + rational6 = {Rational.Add(rational5, rational6)}");
            Console.WriteLine($"rational5 * rational6 = {Rational.Mul(rational5, rational6)}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
