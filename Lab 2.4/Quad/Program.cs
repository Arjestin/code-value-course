namespace Quad
{
    //You are reading command line arguments.
    internal static class Program
    {
        private static void Main()
        {
            var equation = new Equation();
            IO.ReadCoefficients(equation);
            equation.Solve();
            IO.WriteSolution(equation);
        }
    }
}
