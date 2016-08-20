using System;
using Backgammon.Framework.Enumerations;

namespace Backgammon.Framework.Interfaces
{
    public interface IPlayer
    {
        Color ColorOfCheckers { get; }
        Movement Movement { get; set; }
        IPosition Position { get; set; }
        Direction Direction { get; set; }
        int[] Dice { get; set; }
        void Display();
        Command ReadCommand();
        bool ExecuteCommand(Command command);
    }
}
