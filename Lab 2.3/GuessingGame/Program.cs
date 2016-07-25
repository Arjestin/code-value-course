namespace GuessingGame
{
    //Nice job
    internal static class Program
    {
        private static void Main()
        {
            var secret = new Secret();
            while (secret.Counter > 0)
            {
                var guessedNumber = IO.ReadGuessedNumber(secret);
                if (secret.TryGuess(guessedNumber))
                {
                    IO.WriteRightGuess(guessedNumber);
                    break;
                }
                var hint = secret.GetHint(guessedNumber);
                IO.WriteHint(hint);
            }
            if (secret.Counter > 0)
            {
                return;
            }
            var secretNumber = secret.GetSecretNumber();
            IO.WriteWrongGuess(secretNumber);
        }
    }
}
