using System;

namespace Quad
{
    internal class Equation
    {
        internal double A { get; set; }
        internal double B { get; set; }
        internal double C { get; set; }
        internal double X1 { get; private set; }
        internal double X2 { get; private set; }
        internal int NumberOfSolutions { get; private set; }
        internal bool LimitsViolation { get; private set; }

        internal void Solve()
        {
            LimitsViolation = false;
            if (Math.Abs(A) < double.Epsilon && Math.Abs(B) < double.Epsilon && Math.Abs(C) < double.Epsilon)
            {
                NumberOfSolutions = int.MaxValue;
                return;
            }
            if (Math.Abs(A) < double.Epsilon && Math.Abs(B) < double.Epsilon)
            {
                NumberOfSolutions = int.MinValue;
                return;
            }
            if (Math.Abs(A) < double.Epsilon)
            {
                X1 = -(C/B);
                if (double.IsInfinity(X1))
                {
                    LimitsViolation = true;
                }
                else
                {
                    NumberOfSolutions = 1;
                }
                return;
            }
            var discriminant = Math.Pow(B, 2) - 4*A*C;
            if (double.IsInfinity(discriminant))
            {
                LimitsViolation = true;
                return;
            }
            if (discriminant < 0)
            {
                NumberOfSolutions = 0;
                return;
            }
            if (Math.Abs(discriminant) < double.Epsilon)
            {
                X1 = -(B/(2*A));
                if (double.IsInfinity(X1))
                {
                    LimitsViolation = true;
                }
                else
                {
                    NumberOfSolutions = 1;
                }
                return;
            }
            X1 = -((B + Math.Sqrt(discriminant))/(2*A));
            X2 = -((B - Math.Sqrt(discriminant))/(2*A));
            if (double.IsInfinity(X1) || double.IsInfinity(X2))
            {
                LimitsViolation = true;
            }
            else
            {
                NumberOfSolutions = 2;
            }
        }
    }
}
