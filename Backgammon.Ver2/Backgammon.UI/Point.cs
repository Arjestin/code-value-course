using System;
using Backgammon.Framework;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;
using Color = Backgammon.Framework.Enumerations.Color;

namespace Backgammon.UI
{
    public class Point : IPoint
    {
        public Point(int number, IPosition position, Direction direction, Color colorOfCheckers, int numberOfCheckers)
        {
            if (number < 00 || number > 25)
            {
                throw new BackgammonException("BackgammonException: Invalid number parameter in point constructor.");
            }
            if (position == null)
            {
                throw new BackgammonException("BackgammonException: Invalid position parameter in point constructor.");
            }
            if (direction != Direction.None && direction != Direction.Up && direction != Direction.Down)
            {
                throw new BackgammonException("BackgammonException: Invalid direction parameter in point constructor.");
            }
            if (colorOfCheckers != Color.None && colorOfCheckers != Color.Blue && colorOfCheckers != Color.Red)
            {
                throw new BackgammonException("BackgammonException: Invalid color of checkers parameter in point constructor.");
            }
            if (numberOfCheckers < 0 || numberOfCheckers > 15)
            {
                throw new BackgammonException("BackgammonException: Invalid number of checkers parameter in point constructor.");
            }
            if (direction == Direction.None && ((numberOfCheckers > 0) || (number != 00 && number != 25)))
            {
                throw new BackgammonException("BackgammonException: Invalid parameter combination in point constructor.");
            }
            Number = number;
            Position = position;
            Direction = direction;
            ColorOfCheckers = colorOfCheckers;
            NumberOfCheckers = numberOfCheckers;
        }

        public int Number { get; }
        public IPosition Position { get; }
        public Direction Direction { get; }
        public Color ColorOfCheckers { get; set; }
        public int NumberOfCheckers { get; set; }

        public void Display(Color color)
        {
            if (ColorOfCheckers != Color.None && ColorOfCheckers != Color.Blue && ColorOfCheckers != Color.Red)
            {
                throw new BackgammonException("BackgammonException: Invalid color of checkers in point display.");
            }
            if (Direction == Direction.None)
            {
                DisplayBar();
                return;
            }
            if (Direction != Direction.Up && Direction != Direction.Down)
            {
                throw new BackgammonException("BackgammonException: Invalid point direction cannot be displayed.");
            }
            DisplayNumber(Constants.Color.Dictionary[color]);
            DisplayCheckers();
        }

        private void DisplayBar()
        {
            IPosition currentPosition = new Position();
            Console.ForegroundColor = Constants.Color.White;
            Console.SetCursorPosition(Position.Vertical, Position.Horizontal);
            Console.Write('[');
            Console.ForegroundColor = Constants.Color.Dictionary[ColorOfCheckers];
            Console.Write($"{NumberOfCheckers:D2}");
            Console.ForegroundColor = Constants.Color.White;
            Console.Write(']');
            Console.ForegroundColor = Constants.Color.Gray;
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
        }

        private void DisplayNumber(ConsoleColor color)
        {
            IPosition currentPosition = new Position();
            Console.ForegroundColor = color;
            if (Direction == Direction.Up)
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal + 1);
            }
            else
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal - 1);
            }
            Console.Write($"{Number:D2}");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
        }

        private void DisplayCheckers()
        {
            IPosition currentPosition = new Position();
            Console.ForegroundColor = Constants.Color.Dictionary[ColorOfCheckers];
            var currentHorizontalPosition = Position.Horizontal;
            var currentNumberOfCheckers = NumberOfCheckers;
            var checker = ColorOfCheckers == Color.Blue ? "XX" : "OO";
            while (true)
            {
                if ((Direction == Direction.Up && currentHorizontalPosition < Position.Horizontal - 4) || Direction == Direction.Down && currentHorizontalPosition > Position.Horizontal + 4)
                {
                    break;
                }
                Console.SetCursorPosition(Position.Vertical, currentHorizontalPosition);
                if (currentNumberOfCheckers > 0)
                {
                    Console.Write(checker);
                    currentNumberOfCheckers--;
                }
                else
                {
                    Console.Write("  ");
                }
                if (Direction == Direction.Up)
                {
                    currentHorizontalPosition--;
                }
                else
                {
                    currentHorizontalPosition++;
                }
            }
            if (NumberOfCheckers < 6)
            {
                Console.ForegroundColor = Constants.Color.Gray;
                Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
                return;
            }
            if (Direction == Direction.Up)
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal - 4);
            }
            else
            {
                Console.SetCursorPosition(Position.Vertical, Position.Horizontal + 4);
            }
            Console.Write($"{NumberOfCheckers:D2}");
            Console.ForegroundColor = Constants.Color.Gray;
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
        }
    }
}
