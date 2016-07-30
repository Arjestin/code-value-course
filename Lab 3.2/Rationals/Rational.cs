using Rationals.Extensions;

namespace Rationals
{
    //Not struct
    public class Rational
    {
        //This should have been readonly
        private int Numerator { get; set; }

        //This should have been readonly
        private int Denominator { get; set; }

        //Nice.
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

        //This is not object.Equals
        public bool Equals(Rational rational)
        {
            return Numerator == rational.Numerator &&
                   Denominator == rational.Denominator;
        }

        //Why is this static?
        public static Rational Add(Rational rational1, Rational rational2)
        {
            return new Rational(
                rational1.Numerator*rational2.Denominator +
                rational2.Numerator*rational1.Denominator,
                rational1.Denominator*rational2.Denominator);
        }

        //Why is this static?
        public static Rational Mul(Rational rational1, Rational rational2)
        {
            return new Rational(
                rational1.Numerator*rational2.Numerator,
                rational1.Denominator*rational2.Denominator);
        }
    }
}
