namespace Calculator
{
    internal static class Program
    {
        private static void Main()
        {
            var operation = new Operation();
            while (!operation.IsValid())
            {
                var expression = IO.ReadExpression();
                operation = new Operation(expression);
            }
            var result = operation.Calculate();
            if (operation.IsValid())
            {
                IO.WriteResult(result);
            }
        }
    }
}
