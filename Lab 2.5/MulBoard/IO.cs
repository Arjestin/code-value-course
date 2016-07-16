using System;

namespace MulBoard
{
    internal static class IO
    {
        internal static void WriteMulBoard()
        {
            for (var row = 1; row <= 10; ++row)
            {
                for (var column = 1; column <= 10; ++column)
                {
                    Console.Write($"{row*column,4}");
                }
                Console.WriteLine();
            }
        }
    }
}
