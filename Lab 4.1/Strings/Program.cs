using System;

namespace Strings
{
    internal class Program
    {
        private static void Main()
        {
            //Consider the use of do-while loop

            var sentence = Sentence.ReadSentence();

            //while(!string.IsNullOrEmpty(sentence))
            while (string.IsNullOrEmpty(sentence) == false)
            {
                var words = Sentence.WriteSentenceLength(sentence);
                if (words.Length != 0)
                {
                    Words.WriteReversedWords(words);
                    Words.WriteSortedWords(words);
                }
                Console.WriteLine();
                sentence = Sentence.ReadSentence();
            }
        }
    }
}
