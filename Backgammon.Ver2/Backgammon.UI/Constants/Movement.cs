using System;
using System.Collections.Generic;

namespace Backgammon.UI.Constants
{
    public static class Movement
    {
        public static readonly List<ConsoleKey> None = new List<ConsoleKey>
        {
            Command.Escape
        };

        public static readonly List<ConsoleKey> RollDice = new List<ConsoleKey>
        {
            Command.Enter,
            Command.Tab,
            Command.Escape
        };

        public static readonly List<ConsoleKey> SelectChecker = new List<ConsoleKey>
        {
            Command.UpArrow,
            Command.DownArrow,
            Command.LeftArrow,
            Command.RightArrow,
            Command.Enter,
            Command.Tab,
            Command.Escape
        };

        public static readonly List<ConsoleKey> MoveChecker = new List<ConsoleKey>
        {
            Command.UpArrow,
            Command.DownArrow,
            Command.LeftArrow,
            Command.RightArrow,
            Command.Enter,
            Command.Spacebar,
            Command.Tab,
            Command.Escape
        };
    }
}
