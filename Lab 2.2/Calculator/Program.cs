namespace Calculator
{
    internal static class Program
    {
        private static void Main()
        {
            var operation = new Operation();

            //nice
            while (!operation.IsValid())
            {
                var expression = IO.ReadExpression();
                operation = new Operation(expression);
            }
            var result = operation.Calculate();

            //A duplicate?
            if (operation.IsValid())
            {
                IO.WriteResult(result);
            }
        }
    }
}
