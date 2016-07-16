namespace BinaryDisplay
{
    internal static class Program
    {
        private static void Main()
        {
            var number = IO.ReadNumber();
            var binaryNumber = new BinaryNumber(number);
            IO.WriteInfo(binaryNumber);
        }
    }
}
