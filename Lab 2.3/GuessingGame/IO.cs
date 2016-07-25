using System;

namespace GuessingGame
{
    //This IO class isn't a good idea
    internal static class IO
    {
        internal static int ReadGuessedNumber(Secret secret)
        {
            var guessedNumber = 0;
            while (guessedNumber < 1 || guessedNumber > 100)
            {
                var input = string.Empty;
                while (string.IsNullOrEmpty(input))
                {
                    Console.Write($"You have {secret.Counter} tries left to guess a number in the range 1-100: ");
                    input = Console.ReadLine();
                }
                int.TryParse(input, out guessedNumber);
            }
            return guessedNumber;
        }

        internal static void WriteRightGuess(int secretNumber)
        {
            Console.WriteLine();
            Console.WriteLine($"You won. The correct number is {secretNumber}.");
        }

        internal static void WriteHint(bool greaterThan)
        {
            Console.WriteLine();
            Console.WriteLine(greaterThan ? "Too big." : "Too small.");
        }

        internal static void WriteWrongGuess(int secretNumber)
        {
            Console.WriteLine($"You failed. The correct number is {secretNumber}.");
        }
    }
}
