using System;

namespace Backgammon.Framework.Exceptions
{
    public class BackgammonException : Exception
    {
        public BackgammonException()
        {
        }

        public BackgammonException(string message) : base(message)
        {
        }

        public BackgammonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
