using System.Collections;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework.Constants
{
    public static class Setup
    {
        public static readonly IPosition[] Positions =
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

        public static readonly Direction[] Directions =
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

        public static readonly Color[] ColorsOfCheckers =
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

        public static readonly int[] NumbersOfCheckers =
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

        public static readonly int[] Borders =
        {
            1,
            18,
            24,
            41
        };

        public static readonly int[] Dice =
        {
            0,
            0,
            0,
            0
        };

        public static readonly IPosition StartingPosition = new Position(40, 10);
        public const Movement StartingMovement = Movement.RollDice;
    }
}
