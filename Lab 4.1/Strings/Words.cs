using System;

namespace Strings
{
    internal class Words
    {
        internal static void WriteReversedWords(string[] words)
        {
            Array.Reverse(words);
            Console.WriteLine();
            Console.WriteLine("The reversed sentence is:");
            Console.WriteLine(string.Join(" ", words));
        }

        internal static void WriteSortedWords(string[] words)
        {
            Array.Sort(words);
            Console.WriteLine();
            Console.WriteLine("The sorted sentence is:");
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
