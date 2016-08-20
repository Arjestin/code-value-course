using System;
using Backgammon.Framework.Enumerations;

namespace Backgammon.Framework.Interfaces
{
    public interface IPoint
    {
        int Number { get; }
        IPosition Position { get; }
        Direction Direction { get; }
        ConsoleColor ColorOfCheckers { get; set; }
        int NumberOfCheckers { get; set; }
        void Display(ConsoleColor color);
    }
}
