using System;
using System.Collections.Generic;
using System.Linq;
using Backgammon.Framework;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;
using Backgammon.UI.Constants;
using Color = Backgammon.Framework.Enumerations.Color;
using Command = Backgammon.Framework.Enumerations.Command;
using Movement = Backgammon.Framework.Enumerations.Movement;

namespace Backgammon.UI
{
    public class Player : IPlayer
    {
        private readonly IGame _game;

        public Player(IBoard board, Color colorOfCheckers)
        {
            if (colorOfCheckers != Color.Blue && colorOfCheckers != Color.Red)
            {
                throw new BackgammonException("BackgammonException: Invalid color parameter in player constructor.");
            }
            ColorOfCheckers = colorOfCheckers;
            Movement = Setup.StartingMovement;
            Position = Setup.StartingPosition;
            Direction = ColorOfCheckers == Color.Blue ? Direction.Down : Direction.Up;
            Dice = Setup.Dice;
            _game = new Game(board, this);
        }

        public Color ColorOfCheckers { get; }
        public Movement Movement { get; set; }
        public IPosition Position { get; set; }
        public Direction Direction { get; set; }
        public int[] Dice { get; set; }

        public void Display()
        {
            IPosition currentPosition = new Position();
            DisplayMenuHeader();
            switch (Movement)
            {
                case Movement.RollDice:
                    DisplayRollDiceMenu();
                    break;
                case Movement.SelectChecker:
                    DisplaySelectCheckerMenu();
                    DisplayArrow();
                    break;
                case Movement.MoveChecker:
                    DisplayMoveCheckerMenu();
                    DisplayArrow();
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid player movement cannot be displayed.");
            }
            DisplayDefaultMenu();
            DisplayMenuFooter();
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
        }

        public Command ReadCommand()
        {
            var command = Constants.Command.None;
            List<ConsoleKey> movement;
            switch (Movement)
            {
                case Movement.RollDice:
                    movement = Constants.Movement.RollDice;
                    break;
                case Movement.SelectChecker:
                    movement = Constants.Movement.SelectChecker;
                    break;
                case Movement.MoveChecker:
                    movement = Constants.Movement.MoveChecker;
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid player movement.");
            }
            while (!movement.Contains(command))
            {
                command = Console.ReadKey(true).Key;
            }
            return Constants.Command.Dictionary.FirstOrDefault(dictionary => dictionary.Value == command).Key;
        }

        public bool ExecuteCommand(Command command)
        {
            switch (Constants.Command.Dictionary[command])
            {
                case Constants.Command.UpArrow:
                    if (Movement == Movement.SelectChecker || Movement == Movement.MoveChecker)
                    {
                        _game.MoveUp();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.DownArrow:
                    if (Movement == Movement.SelectChecker || Movement == Movement.MoveChecker)
                    {
                        _game.MoveDown();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.LeftArrow:
                    if (Movement == Movement.SelectChecker || Movement == Movement.MoveChecker)
                    {
                        _game.MoveLeft();
                        DisplayArrow();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.RightArrow:
                    if (Movement == Movement.SelectChecker || Movement == Movement.MoveChecker)
                    {
                        _game.MoveRight();
                        DisplayArrow();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.Enter:
                    if (Movement == Movement.RollDice)
                    {
                        _game.RollDice();
                    }
                    else if (Movement == Movement.SelectChecker)
                    {
                        _game.SelectChecker();
                    }
                    else if (Movement == Movement.MoveChecker)
                    {
                        _game.MoveChecker();
                        DisplayArrow();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.Spacebar:
                    if (Movement == Movement.MoveChecker)
                    {
                        _game.ReleaseChecker();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                case Constants.Command.Tab:
                    if (Movement != Movement.None)
                    {
                        _game.PassTurn();
                        DisplayArrow();
                    }
                    else
                    {
                        throw new BackgammonException("BackgammonException: Invalid player movement. Cannot execute command.");
                    }
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid command cannot be executed.");
            }
            return _game.SwitchPlayer;
        }

        private void DisplayMenuHeader()
        {
            Console.Write($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            Console.ForegroundColor = Constants.Color.Dictionary[ColorOfCheckers];
            Console.WriteLine($"                 {Constants.Color.Dictionary[ColorOfCheckers]} Player {Environment.NewLine}");
            Console.ForegroundColor = Constants.Color.Gray;
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
                Console.ForegroundColor = Constants.Color.White;
                Console.Write(Dice[0]);
                Console.ForegroundColor = Constants.Color.Gray;
                Console.Write("                               ");
            }
            else if (Dice[0] == 0 && Dice[1] != 0)
            {
                Console.Write(" Right Die: ");
                Console.ForegroundColor = Constants.Color.White;
                Console.Write(Dice[1]);
                Console.ForegroundColor = Constants.Color.Gray;
                Console.Write("                                ");
            }
            else
            {
                Console.Write(" Left Die: ");
                Console.ForegroundColor = Constants.Color.White;
                Console.Write(Dice[0]);
                Console.ForegroundColor = Constants.Color.Gray;
                Console.Write("                ");
                Console.Write(" Right Die: ");
                Console.ForegroundColor = Constants.Color.White;
                Console.Write(Dice[1]);
                Console.ForegroundColor = Constants.Color.Gray;
                Console.Write("   ");
            }
            if (Dice[2] == 0 && Dice[3] == 0)
            {
                return;
            }
            IPosition currentPosition = new Position();
            if (Dice[2] != 0)
            {
                Console.SetCursorPosition(12, currentPosition.Horizontal);
                Console.Write("x2");
            }
            if (Dice[3] != 0)
            {
                Console.SetCursorPosition(41, currentPosition.Horizontal);
                Console.Write("x2");
            }
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
        }

        private static void DisplayRollDiceMenu()
        {
            Console.Write("| Press <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> to roll the dice.          |");
        }

        private static void DisplaySelectCheckerMenu()
        {
            Console.Write("| Use the <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Arrow");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> keys to navigate.        |");
            Console.Write("| Press <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> to select a checker.       |");
        }

        private static void DisplayMoveCheckerMenu()
        {
            Console.Write("| Use the <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Arrow");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> keys to navigate.        |");
            Console.Write("| Press <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Enter");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> to move the checker.       |");
            Console.Write("| Press <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Spacebar");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.WriteLine("> to release the checker. |");
        }

        private void DisplayDefaultMenu()
        {
            if (Movement != Movement.None)
            {
                Console.Write("| Press <");
                Console.ForegroundColor = Constants.Color.White;
                Console.Write("Tab");
                Console.ForegroundColor = Constants.Color.Gray;
                Console.WriteLine("> to pass your turn.           |");
            }
            Console.Write("| Press <");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write("Escape");
            Console.ForegroundColor = Constants.Color.Gray;
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

        private void DisplayArrow()
        {
            IPosition currentPosition = new Position();
            switch (Movement)
            {
                case Movement.RollDice:
                    Console.ForegroundColor = Constants.Color.None;
                    break;
                case Movement.MoveChecker:
                    Console.ForegroundColor = Constants.Color.Dictionary[ColorOfCheckers];
                    break;
                default:
                    Console.ForegroundColor = Constants.Color.White;
                    break;
            }
            if (Direction == Direction.Down)
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal);
                Console.Write("||");
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal + 1);
                Console.Write(@"\/");
            }
            else
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal);
                Console.Write(@"/\");
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal + 1);
                Console.Write("||");
            }
            Console.ForegroundColor = Constants.Color.Gray;
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
            _game.Display();
        }
    }
}
