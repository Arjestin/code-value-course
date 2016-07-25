using System;
using System.Linq;

namespace BinaryDisplay
{
    internal class BinaryNumber
    {
        internal int Number { get; }
        internal string Binary { get; }
        internal int HammingWeight { get; }

        //The lab asked to use bitwise operations. Though it is nice you are using linq
        private static int CalculateHammingWeight(string binary)
        {
            return binary.Count(digit => digit == '1');
        }

        internal BinaryNumber(int number)
        {
            Number = number;
            Binary = Convert.ToString(Number, 2);
            HammingWeight = CalculateHammingWeight(Binary);
        }
    }
}
