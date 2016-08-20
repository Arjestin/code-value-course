using System;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Enumerations;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;

namespace Backgammon.Framework
{
    public class Game : IGame
    {
        private static readonly Random Random = new Random();
        private readonly IBoard _board;
        private readonly IPlayer _player;
        private static bool _switchPlayer;
        private static IPoint _point;

        public Game(IBoard board, IPlayer player)
        {
            _board = board;
            _player = player;
            _switchPlayer = false;
        }

        public bool SwitchPlayer
        {
            get
            {
                if (!_switchPlayer)
                {
                    return false;
                }
                _switchPlayer = false;
                return true;
            }
        }

        public void RollDice()
        {
            _player.Dice[0] = Random.Next(1, 7);
            _player.Dice[1] = Random.Next(1, 7);
            if (_player.Dice[0] == _player.Dice[1])
            {
                _player.Dice[2] = _player.Dice[0];
                _player.Dice[3] = _player.Dice[1];
            }
            _player.Movement = Movement.SelectChecker;
        }

        public void MoveUp()
        {
            _player.Direction = Direction.Up;
            Display();
        }

        public void MoveDown()
        {
            _player.Direction = Direction.Down;
            Display();
        }

        public void MoveLeft()
        {
            if (_player.Position.Vertical > Setup.Borders[0] && _player.Position.Vertical < Setup.Borders[1])
            {
                if (_player.Position.Vertical - 3 < Setup.Borders[0])
                {
                    return;
                }
                MoveHorizontally(Direction.Left, false);
            }
            else if (_player.Position.Vertical > Setup.Borders[2] && _player.Position.Vertical < Setup.Borders[3])
            {
                MoveHorizontally(Direction.Left, _player.Position.Vertical - 3 < Setup.Borders[2]);
            }
            else
            {
                throw new BackgammonException("BackgammonException: Invalid game position.");
            }
        }

        public void MoveRight()
        {
            if (_player.Position.Vertical > Setup.Borders[0] && _player.Position.Vertical < Setup.Borders[1])
            {
                MoveHorizontally(Direction.Right, _player.Position.Vertical + 3 > Setup.Borders[1]);
            }
            else if (_player.Position.Vertical > Setup.Borders[2] && _player.Position.Vertical < Setup.Borders[3])
            {
                if (_player.Position.Vertical + 3 > Setup.Borders[3])
                {
                    return;
                }
                MoveHorizontally(Direction.Right, false);
            }
            else
            {
                throw new BackgammonException("BackgammonException: Invalid game position.");
            }
        }

        public void SelectChecker()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != _player.Position.Vertical || _board.Points[i].Direction == _player.Direction || _board.Points[i].ColorOfCheckers != _player.ColorOfCheckers)
                {
                    continue;
                }
                _point = _board.Points[i];
                _point.NumberOfCheckers--;
                if (_point.NumberOfCheckers == 0)
                {
                    _point.ColorOfCheckers = Color.None;
                }
                _player.Movement = Movement.MoveChecker;
                _board.Points[i].Display(Color.Magenta);
            }
        }

        public void MoveChecker()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != _player.Position.Vertical || _board.Points[i].Direction == _player.Direction || ((_player.ColorOfCheckers == Color.Blue && _board.Points[i].ColorOfCheckers == Color.Red || _player.ColorOfCheckers == Color.Red && _board.Points[i].ColorOfCheckers == Color.Blue) && _board.Points[i].NumberOfCheckers > 1) || _player.ColorOfCheckers == Color.Blue && _board.Points[i].Number < _point.Number || _player.ColorOfCheckers == Color.Red && _board.Points[i].Number > _point.Number)
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
                    _player.Movement = Movement.SelectChecker;
                    break;
                }
                if (_player.Dice[0] != 0 || _player.Dice[1] != 0)
                {
                    break;
                }
                _player.Movement = Movement.RollDice;
                _switchPlayer = true;
                break;
            }
        }

        public void ReleaseChecker()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_board.Points[i].Position.Vertical != _player.Position.Vertical || _board.Points[i].Direction == _player.Direction)
                {
                    continue;
                }
                if (_point != null)
                {
                    _point.ColorOfCheckers = _player.ColorOfCheckers;
                    _point.NumberOfCheckers++;
                }
                _point = null;
                _player.Movement = Movement.SelectChecker;
                _board.Points[i].Display(Color.White);
            }
        }

        public void PassTurn()
        {
            if (_player.Movement == Movement.MoveChecker)
            {
                ReleaseChecker();
            }
            _player.Dice = new[] {0, 0, 0, 0};
            _player.Movement = Movement.RollDice;
            _switchPlayer = true;
        }

        public void Display()
        {
            for (var i = 1; i < 25; ++i)
            {
                if (_point != null && _board.Points[i] == _point)
                {
                    _board.Points[i].Display(Color.Magenta);
                }
                else if (_board.Points[i].Position.Vertical == _player.Position.Vertical && _board.Points[i].Direction != _player.Direction)
                {
                    if (_player.Movement == Movement.RollDice)
                    {
                        _board.Points[i].Display(Color.White);
                    }
                    else if (_player.Movement == Movement.SelectChecker && _board.Points[i].ColorOfCheckers == _player.ColorOfCheckers)
                    {
                        _board.Points[i].Display(Color.Magenta);
                    }
                    else if (_point != null && _player.Movement == Movement.MoveChecker && ((_player.Dice[0] != 0 && Math.Abs(_board.Points[i].Number - _point.Number) == _player.Dice[0]) || (_player.Dice[1] != 0 && Math.Abs(_board.Points[i].Number - _point.Number) == _player.Dice[1])) && (((_player.ColorOfCheckers != Color.Blue || _board.Points[i].ColorOfCheckers != Color.Red) && (_player.ColorOfCheckers != Color.Red || _board.Points[i].ColorOfCheckers != Color.Blue)) || _board.Points[i].NumberOfCheckers <= 1) && (_player.ColorOfCheckers == Color.Blue && _board.Points[i].Number > _point.Number || _player.ColorOfCheckers == Color.Red && _board.Points[i].Number < _point.Number))
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
            IPosition currentPosition = new Position();
            Console.SetCursorPosition(_player.Position.Vertical, _player.Position.Horizontal);
            Console.Write("  ");
            Console.SetCursorPosition(_player.Position.Vertical, _player.Position.Horizontal + 1);
            Console.Write("  ");
            Console.SetCursorPosition(currentPosition.Vertical, currentPosition.Horizontal);
            switch (direction)
            {
                case Direction.Left:
                    if (moveOverTheBar)
                    {
                        _player.Position.Vertical -= 8;
                    }
                    else
                    {
                        _player.Position.Vertical -= 3;
                    }
                    break;
                case Direction.Right:
                    if (moveOverTheBar)
                    {
                        _player.Position.Vertical += 8;
                    }
                    else
                    {
                        _player.Position.Vertical += 3;
                    }
                    break;
                default:
                    throw new BackgammonException("BackgammonException: Invalid game direction.");
            }
        }
    }
}
