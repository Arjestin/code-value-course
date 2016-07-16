using System;

namespace GuessingGame
{
    internal class Secret
    {
        private const int NumberOfTries = 7;
        private int SecretNumber { get; }
        internal int Counter { get; private set; }

        internal Secret()
        {
            SecretNumber = new Random().Next(1, 101);
            Counter = NumberOfTries;
        }

        internal bool TryGuess(int guessedNumber)
        {
            return guessedNumber == SecretNumber;
        }

        internal bool GetHint(int guessedNumber)
        {
            --Counter;
            return guessedNumber > SecretNumber;
        }

        internal int GetSecretNumber()
        {
            return Counter == 0 ? SecretNumber : 0;
        }
    }
}
