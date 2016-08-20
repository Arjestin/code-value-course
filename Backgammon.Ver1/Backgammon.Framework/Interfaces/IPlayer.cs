using System;
using System.Collections.Generic;

namespace Backgammon.Framework.Interfaces
{
    public interface IPlayer
    {
        ConsoleColor ColorOfCheckers { get; }
        List<ConsoleKey> MovementOptions { get; set; }
        int[] Dice { get; set; }
        void Display();
        ConsoleKey ReadCommand();
        bool ExecuteCommand(ConsoleKey command);
    }
}
