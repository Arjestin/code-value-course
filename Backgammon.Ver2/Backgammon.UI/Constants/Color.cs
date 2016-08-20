using System;
using System.Collections.Generic;

namespace Backgammon.UI.Constants
{
    public static class Color
    {
        public const ConsoleColor None = ConsoleColor.Black;
        public const ConsoleColor Gray = ConsoleColor.Gray;
        public const ConsoleColor White = ConsoleColor.White;
        public const ConsoleColor Blue = ConsoleColor.Blue;
        public const ConsoleColor Red = ConsoleColor.Red;
        public const ConsoleColor Magenta = ConsoleColor.Magenta;
        public const ConsoleColor Green = ConsoleColor.Green;

        public static readonly Dictionary<Framework.Enumerations.Color, ConsoleColor> Dictionary = new Dictionary<Framework.Enumerations.Color, ConsoleColor>
        {
            {Framework.Enumerations.Color.None, ConsoleColor.Black},
            {Framework.Enumerations.Color.Gray, ConsoleColor.Gray},
            {Framework.Enumerations.Color.White, ConsoleColor.White},
            {Framework.Enumerations.Color.Blue, ConsoleColor.Blue},
            {Framework.Enumerations.Color.Red, ConsoleColor.Red},
            {Framework.Enumerations.Color.Magenta, ConsoleColor.Magenta},
            {Framework.Enumerations.Color.Green, ConsoleColor.Green}
        };
    }
}
