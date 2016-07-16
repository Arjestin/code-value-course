using System;
using System.Linq;

namespace Strings
{
    internal class Sentence
    {
        private static readonly char[] DelimiterChars = {' ', ',', '.', ':', ';', '!', '?', '\t'};

        internal static string ReadSentence()
        {
            Console.WriteLine("Enter a sentence, or press enter to exit.");
            return Console.ReadLine();
        }

        internal static string[] WriteSentenceLength(string sentence)
        {
            var words = sentence.Split(DelimiterChars);
            words = words.Where(word => word != string.Empty).ToArray();
            Console.WriteLine();
            Console.WriteLine($"There are {words.Length} words in the sentence.");
            return words;
        }
    }
}
