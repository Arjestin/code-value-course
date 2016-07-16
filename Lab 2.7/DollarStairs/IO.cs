using System;

namespace DollarStairs
{
    internal static class IO
    {
        internal static uint ReadNumber()
        {
            uint number;
            var input = string.Empty;
            while (!uint.TryParse(input, out number))
            {
                Console.Write("Enter a number of type unsigned integer: ");
                input = Console.ReadLine();
            }
            return number;
        }

        internal static void WriteDollarStairs(uint number)
        {
            for (var i = 0; i <= number; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    Console.Write('$');
                }
                Console.WriteLine();
            }
        }
    }
}
