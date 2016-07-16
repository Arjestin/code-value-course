using System;

namespace BinaryDisplay
{
    internal static class IO
    {
        internal static int ReadNumber()
        {
            int number;
            var input = string.Empty;
            while (!int.TryParse(input, out number))
            {
                Console.Write("Enter a number of type integer: ");
                input = Console.ReadLine();
            }
            return number;
        }

        internal static void WriteInfo(BinaryNumber binaryNumber)
        {
            Console.WriteLine();
            Console.WriteLine($"Integer representation:\t{binaryNumber.Number}");
            Console.WriteLine($"Binary representation:\t{binaryNumber.Binary}");
            Console.WriteLine($"Hamming weight:\t\t{binaryNumber.HammingWeight}");
        }
    }
}
