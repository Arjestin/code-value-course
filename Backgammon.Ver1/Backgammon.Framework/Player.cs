using System;
using System.Collections.Generic;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework
{
    public class Player : IPlayer
    {
        private static readonly Random Random = new Random();
        private readonly IArrow _arrow;

        public Player(IBoard board, ConsoleColor colorOfCheckers)
        {
            ColorOfCheckers = colorOfCheckers;
            MovementOptions = Movement.RollDice;
            Dice = new[] {0, 0, 0, 0};
            _arrow = new Arrow(board, this);
        }

        public ConsoleColor ColorOfCheckers { get; }
        public List<ConsoleKey> MovementOptions { get; set; }
        public int[] Dice { get; set; }

        public void Display()
        {
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            DisplayMenuHeader();
            if (MovementOptions == Movement.RollDice)
            {
                DisplayRollDiceMenu();
            }
            else if (MovementOptions == Movement.SelectChecker)
            {
                DisplaySelectCheckerMenu();
                _arrow.Display();
            }
            else if (MovementOptions == Movement.MoveChecker)
            {
                DisplayMoveCheckerMenu();
                _arrow.Display();
            }
            else
            {
                throw new BackgammonException("BackgammonException: Invalid player movement cannot be displayed.");
            }
            DisplayDefaultMenu();
            DisplayMenuFooter();
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        public ConsoleKey ReadCommand()
        {
            var command = Command.None;
            while (!MovementOptions.Contains(command))
            {
                command = Console.ReadKey(true).Key;
            }
            return command;
        }

        public bool ExecuteCommand(ConsoleKey command)
        {
            var switchPlayer = false;
            switch (command)
            {
                case Command.UpArrow:
                    if (MovementOptions == Movement.SelectChecker || MovementOptions == Movement.MoveChecker)
                    {
                        _arrow.MoveUp();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.DownArrow:
                    if (MovementOptions == Movement.SelectChecker || MovementOptions == Movement.MoveChecker)
                    {
                        _arrow.MoveDown();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.LeftArrow:
                    if (MovementOptions == Movement.SelectChecker || MovementOptions == Movement.MoveChecker)
                    {
                        _arrow.MoveLeft();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.RightArrow:
                    if (MovementOptions == Movement.SelectChecker || MovementOptions == Movement.MoveChecker)
                    {
                        _arrow.MoveRight();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.Enter:
                    if (MovementOptions == Movement.RollDice)
                    {
                        RollDice();
                    }
                    else if (MovementOptions == Movement.SelectChecker)
                    {
                        _arrow.SelectChecker();
                    }
                    else if (MovementOptions == Movement.MoveChecker)
                    {
                        switchPlayer = _arrow.MoveChecker();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.Spacebar:
                    if (MovementOptions == Movement.MoveChecker)
                    {
                        _arrow.ReleaseChecker();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Command.Tab:
                    if (MovementOptions != Movement.None)
                    {
                        PassTurn();
                        switchPlayer = true;
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid command cannot be executed.");
            }
            return switchPlayer;
        }

        private void DisplayMenuHeader()
        {
            Console.Write($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            Console.ForegroundColor = ColorOfCheckers;
            Console.WriteLine($"                 {ColorOfCheckers} Player {Environment.NewLine}");
            Console.ForegroundColor = Color.Gray;
            DisplayDice();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("|——————————————————————————————————————————|");
            Console.WriteLine("|                                          |");
        }

        private void DisplayDice()
        {
            if (Dice[0] == 0 && Dice[1] == 0)
            {
                Console.Write("                                            ");
            }
            else if (Dice[0] != 0 && Dice[1] == 0)
            {
                Console.Write(" Left Die: ");
                Console.ForegroundColor = Color.White;
                Console.Write(Dice[0]);
                Console.ForegroundColor = Color.Gray;
                Console.Write("                               ");
            }
            else if (Dice[0] == 0 && Dice[1] != 0)
            {
                Console.Write(" Right Die: ");
                Console.ForegroundColor = Color.White;
                Console.Write(Dice[1]);
                Console.ForegroundColor = Color.Gray;
                Console.Write("                                ");
            }
            else
            {
                Console.Write(" Left Die: ");
                Console.ForegroundColor = Color.White;
                Console.Write(Dice[0]);
                Console.ForegroundColor = Color.Gray;
                Console.Write("                ");
                Console.Write(" Right Die: ");
                Console.ForegroundColor = Color.White;
                Console.Write(Dice[1]);
                Console.ForegroundColor = Color.Gray;
                Console.Write("   ");
            }
            if (Dice[2] == 0 && Dice[3] == 0)
            {
                return;
            }
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            if (Dice[2] != 0)
            {
                Console.SetCursorPosition(12, cursorTop);
                Console.Write("x2");
            }
            if (Dice[3] != 0)
            {
                Console.SetCursorPosition(41, cursorTop);
                Console.Write("x2");
            }
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        private static void DisplayRollDiceMenu()
        {
            Console.Write("| Press <");
            Console.ForegroundColor = Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> to roll the dice.          |");
        }

        private static void DisplaySelectCheckerMenu()
        {
            Console.Write("| Use the <");
            Console.ForegroundColor = Color.White;
            Console.Write("Arrow");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> keys to navigate.        |");
            Console.Write("| Press <");
            Console.ForegroundColor = Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> to select a checker.       |");
        }

        private static void DisplayMoveCheckerMenu()
        {
            Console.Write("| Use the <");
            Console.ForegroundColor = Color.White;
            Console.Write("Arrow");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> keys to navigate.        |");
            Console.Write("| Press <");
            Console.ForegroundColor = Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> to move the checker.       |");
            Console.Write("| Press <");
            Console.ForegroundColor = Color.White;
            Console.Write("Spacebar");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> to release the checker. |");
        }

        private void DisplayDefaultMenu()
        {
            if (MovementOptions != Movement.None)
            {
                Console.Write("| Press <");
                Console.ForegroundColor = Color.White;
                Console.Write("Tab");
                Console.ForegroundColor = Color.Gray;
                Console.WriteLine("> to pass your turn.           |");
            }
            Console.Write("| Press <");
            Console.ForegroundColor = Color.White;
            Console.Write("Escape");
            Console.ForegroundColor = Color.Gray;
            Console.WriteLine("> to quit the game.         |");
        }

        private static void DisplayMenuFooter()
        {
            Console.WriteLine("|                                          |");
            Console.WriteLine("|——————————————————————————————————————————|");
            for (var i = 0; i < 2; ++i)
            {
                Console.WriteLine("                                            ");
            }
        }

        private void RollDice()
        {
            Dice[0] = Random.Next(1, 7);
            Dice[1] = Random.Next(1, 7);
            if (Dice[0] == Dice[1])
            {
                Dice[2] = Dice[0];
                Dice[3] = Dice[1];
            }
            MovementOptions = Movement.SelectChecker;
        }

        private void PassTurn()
        {
            if (MovementOptions == Movement.MoveChecker)
            {
                _arrow.ReleaseChecker();
            }
            Dice = new[] {0, 0, 0, 0};
            MovementOptions = Movement.RollDice;
            _arrow.Display();
        }
    }
}
