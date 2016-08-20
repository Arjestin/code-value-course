using System;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework
{
    public class Position : IPosition
    {
        public Position()
        {
            if (Console.CursorLeft < 0)
            {
                throw new BackgammonException("BackgammonException: Invalid vertical parameter in position constructor.");
            }
            if (Console.CursorTop < 0)
            {
                throw new BackgammonException("BackgammonException: Invalid horizontal parameter in position constructor.");
            }
            Vertical = Console.CursorLeft;
            Horizontal = Console.CursorTop;
        }

        public Position(int vertical, int horizontal)
        {
            if (vertical < 0)
            {
                throw new BackgammonException("BackgammonException: Invalid vertical parameter in position constructor.");
            }
            if (horizontal < 0)
            {
                throw new BackgammonException("BackgammonException: Invalid horizontal parameter in position constructor.");
            }
            Vertical = vertical;
            Horizontal = horizontal;
        }

        public int Vertical { get; set; }
        public int Horizontal { get; set; }
    }
}
