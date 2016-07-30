using System;

namespace Rationals
{
    internal class Program
    {
        private static void Main()
        {
            Rational num1 = new Rational(1, 2);
            Rational num2 = new Rational(1, 2);

            Rational num3 = Rational.Add(num1, num2);

            Rational num4 = Rational.Mul(num2, num2);

            Rational num6 = new Rational(2, 4);
            Rational num7 = new Rational(2, 4);
            //num7.Reduce();


            Console.WriteLine($"{num1} + {num2} = {num3}");
            Console.WriteLine($"{num2} * {num2} = {num4}");
            Console.WriteLine($"{num6} reduced {num7}");
        }
    }
}
