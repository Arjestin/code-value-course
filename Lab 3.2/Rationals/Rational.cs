using Rationals.Extensions;

namespace Rationals
{
    public class Rational
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }
        public double Value => (double) Numerator/Denominator;

        private void Reduce()
        {
            var gcd = Math.FindGcd(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            if (Denominator >= 0)
            {
                return;
            }
            Numerator *= -1;
            Denominator *= -1;
        }

        public Rational(int numerator, int denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;
            if (Denominator == 0)
            {
                Numerator = 0;
            }
            else
            {
                Reduce();
            }
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public bool Equals(Rational rational)
        {
            return Numerator == rational.Numerator &&
                   Denominator == rational.Denominator;
        }

        public static Rational Add(Rational rational1, Rational rational2)
        {
            return new Rational(
                rational1.Numerator*rational2.Denominator +
                rational2.Numerator*rational1.Denominator,
                rational1.Denominator*rational2.Denominator);
        }

        public static Rational Mul(Rational rational1, Rational rational2)
        {
            return new Rational(
                rational1.Numerator*rational2.Numerator,
                rational1.Denominator*rational2.Denominator);
        }
    }
}
