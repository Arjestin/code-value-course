using System;
using System.Threading.Tasks;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework
{
    public class Board : IBoard
    {
        private static bool _isDisplayed;

        private static readonly IPosition[] Positions =
        {
            new Position(20, 10),
            new Position(40, 17),
            new Position(37, 17),
            new Position(34, 17),
            new Position(31, 17),
            new Position(28, 17),
            new Position(25, 17),
            new Position(17, 17),
            new Position(14, 17),
            new Position(11, 17),
            new Position(08, 17),
            new Position(05, 17),
            new Position(02, 17),
            new Position(02, 04),
            new Position(05, 04),
            new Position(08, 04),
            new Position(11, 04),
            new Position(14, 04),
            new Position(17, 04),
            new Position(25, 04),
            new Position(28, 04),
            new Position(31, 04),
            new Position(34, 04),
            new Position(37, 04),
            new Position(40, 04),
            new Position(20, 11)
        };

        private static readonly Direction[] Directions =
        {
            Direction.None,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Up,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.Down,
            Direction.None
        };

        private static readonly ConsoleColor[] ColorsOfCheckers =
        {
            Color.Blue,
            Color.Blue,
            Color.None,
            Color.None,
            Color.None,
            Color.None,
            Color.Red,
            Color.None,
            Color.Red,
            Color.None,
            Color.None,
            Color.None,
            Color.Blue,
            Color.Red,
            Color.None,
            Color.None,
            Color.None,
            Color.Blue,
            Color.None,
            Color.Blue,
            Color.None,
            Color.None,
            Color.None,
            Color.None,
            Color.Red,
            Color.Red
        };

        private static readonly int[] NumbersOfCheckers =
        {
            0,
            2,
            0,
            0,
            0,
            0,
            5,
            0,
            3,
            0,
            0,
            0,
            5,
            5,
            0,
            0,
            0,
            3,
            0,
            5,
            0,
            0,
            0,
            0,
            2,
            0
        };

        public Board()
        {
            Points = new IPoint[26];
            Parallel.For(00, 26, i => Points[i] = new Point(i, Positions[i], Directions[i], ColorsOfCheckers[i], NumbersOfCheckers[i]));
        }

        public IPoint[] Points { get; set; }

        public void Display()
        {
            if (_isDisplayed)
            {
                return;
            }
            DisplayTitle();
            DisplayBorders();
            DisplayPoints();
            _isDisplayed = true;
        }

        private static void DisplayTitle()
        {
            Console.ForegroundColor = Color.White;
            Console.WriteLine("          CodeValue Backgammon 1986         ");
            Console.ForegroundColor = Color.Gray;
        }

        private static void DisplayBorders()
        {
            Console.WriteLine();
            Console.WriteLine("|———————————————————|——|———————————————————|");
            for (var i = 0; i < 16; ++i)
            {
                Console.WriteLine("|                   |  |                   |");
            }
            Console.WriteLine("|———————————————————|——|———————————————————|");
        }

        private void DisplayPoints()
        {
            for (var i = 0; i < 26; ++i)
            {
                Points[i].Display(Color.White);
            }
        }
    }
}
