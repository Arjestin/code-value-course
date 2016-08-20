using System;
using System.Collections.Generic;

namespace Backgammon.UI.Constants
{
    public static class Command
    {
        public const ConsoleKey None = ConsoleKey.Home;
        public const ConsoleKey UpArrow = ConsoleKey.UpArrow;
        public const ConsoleKey DownArrow = ConsoleKey.DownArrow;
        public const ConsoleKey LeftArrow = ConsoleKey.LeftArrow;
        public const ConsoleKey RightArrow = ConsoleKey.RightArrow;
        public const ConsoleKey Enter = ConsoleKey.Enter;
        public const ConsoleKey Spacebar = ConsoleKey.Spacebar;
        public const ConsoleKey Tab = ConsoleKey.Tab;
        public const ConsoleKey Escape = ConsoleKey.Escape;

        public static readonly Dictionary<Framework.Enumerations.Command, ConsoleKey> Dictionary = new Dictionary<Framework.Enumerations.Command, ConsoleKey>
        {
            {Framework.Enumerations.Command.None, ConsoleKey.Home},
            {Framework.Enumerations.Command.Up, ConsoleKey.UpArrow},
            {Framework.Enumerations.Command.Down, ConsoleKey.DownArrow},
            {Framework.Enumerations.Command.Left, ConsoleKey.LeftArrow},
            {Framework.Enumerations.Command.Right, ConsoleKey.RightArrow},
            {Framework.Enumerations.Command.Select, ConsoleKey.Enter},
            {Framework.Enumerations.Command.Release, ConsoleKey.Spacebar},
            {Framework.Enumerations.Command.Pass, ConsoleKey.Tab},
            {Framework.Enumerations.Command.Quit, ConsoleKey.Escape}
        };
    }
}
