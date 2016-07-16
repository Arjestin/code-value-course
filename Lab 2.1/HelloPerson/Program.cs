namespace HelloPerson
{
    internal static class Program
    {
        private static void Main()
        {
            var name = IO.ReadName();
            var number = IO.ReadNumber();
            IO.WriteOutput(name, number);
        }
    }
}
