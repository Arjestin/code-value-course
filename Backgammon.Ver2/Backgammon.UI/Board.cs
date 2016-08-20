using System;
using System.Threading.Tasks;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Interfaces;

namespace Backgammon.UI
{
    public class Board : IBoard
    {
        private static bool _isDisplayed;

        public Board()
        {
            Points = new IPoint[26];
            Parallel.For(00, 26, i => Points[i] = new Point(i, Setup.Positions[i], Setup.Directions[i], Setup.ColorsOfCheckers[i], Setup.NumbersOfCheckers[i]));
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
            Console.ForegroundColor = Constants.Color.White;
            Console.WriteLine("          CodeValue Backgammon 1986         ");
            Console.ForegroundColor = Constants.Color.Gray;
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
