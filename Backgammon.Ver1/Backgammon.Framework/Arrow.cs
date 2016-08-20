using System;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework
{
    public class Arrow : IArrow
    {
        private static readonly int[] Borders = {1, 18, 24, 41};
        private readonly IBoard _board;
        private readonly IPlayer _player;
        private static IPoint _point;

        public Arrow(IBoard board, IPlayer player)
        {
            _board = board;
            _player = player;
            Position = new Position(40, 10);
            switch (_player.ColorOfCheckers)
            {
                case Color.Blue:
                    Direction = Direction.Down;
                    break;
                case Color.Red:
                    Direction = Direction.Up;
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid player color parameter in arrow constructor.");
            }
        }

        public IPosition Position { get; }
        public Direction Direction { get; private set; }

        public void Display()
        {
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            if (_player.MovementOptions == Movement.RollDice)
            {
                Console.ForegroundColor = Color.None;
            }
            else if (_player.MovementOptions == Movement.MoveChecker)
            {
                Console.ForegroundColor = _player.ColorOfCheckers;
            }
            else
            {
                Console.ForegroundColor = Color.White;
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
            Console.ForegroundColor = Color.Gray;
            Console.SetCursorPosition(cursorLeft, cursorTop);
            HighlightPointNumber();
        }

        public void MoveUp()
        {
            Direction = Direction.Up;
            HighlightPointNumber();
        }

        public void MoveDown()
        {
            Direction = Direction.Down;
            HighlightPointNumber();
        }

        public void MoveLeft()
        {
            if (Position.Vertical > Borders[0] && Position.Vertical < Borders[1])
            {
                if (Position.Vertical - 3 < Borders[0])
                {
                    return;
                }
                MoveHorizontally(Direction.Left, false);
            }
            else if (Position.Vertical > Borders[2] && Position.Vertical < Borders[3])
            {
                MoveHorizontally(Direction.Left, Position.Vertical - 3 < Borders[2]);
            }
            else
            {
                throw new BackgammonException("BackgammonException: Invalid arrow position.");
            }
        }

        public void MoveRight()
        {
            if (Position.Vertical > Borders[0] && Position.Vertical < Borders[1])
            {
                MoveHorizontally(Direction.Right, Position.Vertical + 3 > Borders[1]);
            }
            else if (Position.Vertical > Borders[2] && Position.Vertical < Borders[3])
            {
                if (Position.Vertical + 3 > Borders[3])
                {
                    return;
                }
                MoveHorizontally(Direction.Right, false);
            }
            else
            {
                throw new BackgammonException("BackgammonException: Invalid arrow position.");
            }
        }

        public void SelectChecker()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != Position.Vertical || _board.Points[i].Direction == Direction || _board.Points[i].ColorOfCheckers != _player.ColorOfCheckers)
                {
                    continue;
                }
                _point = _board.Points[i];
                _point.NumberOfCheckers--;
                _board.Points[i].Display(Color.Magenta);
                _player.MovementOptions = Movement.MoveChecker;
                break;
            }
        }

        public bool MoveChecker()
        {
            var switchPlayer = false;
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != Position.Vertical || _board.Points[i].Direction == Direction || ((_player.ColorOfCheckers == Color.Blue && _board.Points[i].ColorOfCheckers == Color.Red || _player.ColorOfCheckers == Color.Red && _board.Points[i].ColorOfCheckers == Color.Blue) && _board.Points[i].NumberOfCheckers > 1) || _player.ColorOfCheckers == Color.Blue && _board.Points[i].Number < _point.Number || _player.ColorOfCheckers == Color.Red && _board.Points[i].Number > _point.Number)
                {
                    continue;
                }
                for (var j = 3; j >= 0; --j)
                {
                    if (_point == null || _player.Dice[j] == 0 || Math.Abs(_board.Points[i].Number - _point.Number) != _player.Dice[j])
                    {
                        continue;
                    }
                    if ((_player.ColorOfCheckers == Color.Blue && _board.Points[i].ColorOfCheckers == Color.Red || _player.ColorOfCheckers == Color.Red && _board.Points[i].ColorOfCheckers == Color.Blue) && _board.Points[i].NumberOfCheckers == 1)
                    {
                        _board.Points[i].NumberOfCheckers--;
                        var k = _player.ColorOfCheckers == Color.Blue ? 25 : 00;
                        _board.Points[k].NumberOfCheckers++;
                        _board.Points[k].Display(Color.None);
                    }
                    _board.Points[i].ColorOfCheckers = _player.ColorOfCheckers;
                    _board.Points[i].NumberOfCheckers++;
                    _point = null;
                    _player.Dice[j] = 0;
                    _player.MovementOptions = Movement.SelectChecker;
                    break;
                }
                if (_player.Dice[0] != 0 || _player.Dice[1] != 0)
                {
                    break;
                }
                _player.MovementOptions = Movement.RollDice;
                Display();
                switchPlayer = true;
                break;
            }
            return switchPlayer;
        }

        public void ReleaseChecker()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != Position.Vertical || _board.Points[i].Direction == Direction)
                {
                    continue;
                }
                _point.ColorOfCheckers = _player.ColorOfCheckers;
                _point.NumberOfCheckers++;
                _point = null;
                _board.Points[i].Display(Color.White);
                _player.MovementOptions = Movement.SelectChecker;
                break;
            }
        }

        private void HighlightPointNumber()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_point != null && _board.Points[i] == _point)
                {
                    _board.Points[i].Display(Color.Magenta);
                }
                else if (_board.Points[i].Position.Vertical == Position.Vertical && _board.Points[i].Direction != Direction)
                {
                    if (_player.MovementOptions == Movement.RollDice)
                    {
                        _board.Points[i].Display(Color.White);
                    }
                    else if (_player.MovementOptions == Movement.SelectChecker && _board.Points[i].ColorOfCheckers == _player.ColorOfCheckers)
                    {
                        _board.Points[i].Display(Color.Magenta);
                    }
                    else if (_point != null && _player.MovementOptions == Movement.MoveChecker && ((_player.Dice[0] != 0 && Math.Abs(_board.Points[i].Number - _point.Number) == _player.Dice[0]) || (_player.Dice[1] != 0 && Math.Abs(_board.Points[i].Number - _point.Number) == _player.Dice[1])) && (((_player.ColorOfCheckers != Color.Blue || _board.Points[i].ColorOfCheckers != Color.Red) && (_player.ColorOfCheckers != Color.Red || _board.Points[i].ColorOfCheckers != Color.Blue)) || _board.Points[i].NumberOfCheckers <= 1) && (_player.ColorOfCheckers == Color.Blue && _board.Points[i].Number > _point.Number || _player.ColorOfCheckers == Color.Red && _board.Points[i].Number < _point.Number))
                    {
                        _board.Points[i].Display(Color.Green);
                    }
                }
                else
                {
                    _board.Points[i].Display(Color.White);
                }
            }
        }

        private void MoveHorizontally(Direction direction, bool moveOverTheBar)
        {
            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;
            Console.SetCursorPosition(Position.Vertical, Position.Horizontal);
            Console.Write("  ");
            Console.SetCursorPosition(Position.Vertical, Position.Horizontal + 1);
            Console.Write("  ");
            Console.SetCursorPosition(cursorLeft, cursorTop);
            switch (direction)
            {
                case Direction.Left:
                    if (moveOverTheBar)
                    {
                        Position.Vertical -= 8;
                    }
                    else
                    {
                        Position.Vertical -= 3;
                    }
                    break;
                case Direction.Right:
                    if (moveOverTheBar)
                    {
                        Position.Vertical += 8;
                    }
                    else
                    {
                        Position.Vertical += 3;
                    }
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid direction for arrow to move.");
            }
            Display();
        }
    }
}
