using System;
using System.IO;
using System.Media;
using System.Security;
using Backgammon.Framework;
using Backgammon.Framework.Constants;
using Backgammon.Framework.Exceptions;
using Backgammon.Framework.Interfaces;
using Backgammon.UI.Properties;

namespace Backgammon.UI
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                OpenGame();
                IBoard board = new Board();
                board.Display();
                IPlayer bluePlayer = new Player(board, Color.Blue);
                IPlayer redPlayer = new Player(board, Color.Red);
                var currentPlayer = bluePlayer;
                while (true)
                {
                    currentPlayer.Display();
                    var command = currentPlayer.ReadCommand();
                    if (command == Command.Escape)
                    {
                        break;
                    }
                    var switchPlayer = currentPlayer.ExecuteCommand(command);
                    if (switchPlayer)
                    {
                        currentPlayer = currentPlayer == bluePlayer ? redPlayer : bluePlayer;
                    }
                }
            }
            catch (Exception exception) when
                (
                exception is BackgammonException ||
                exception is IOException ||
                exception is SecurityException ||
                exception is ArgumentNullException ||
                exception is ArgumentException ||
                exception is InvalidOperationException ||
                exception is TimeoutException
                )
            {
                Console.WriteLine();
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseGame();
            }
        }

        private static void OpenGame()
        {
            using (var soundPlayer = new SoundPlayer(Resources.SoundLoop))
            {
                soundPlayer.LoadTimeout = 1000;
                soundPlayer.PlayLooping();
                Console.CursorVisible = false;
                Console.WriteLine("|——————————————————————————————————————————|");
                Console.WriteLine("|                                          |");
                Console.Write("|   ");
                Console.ForegroundColor = Color.White;
                Console.Write("Wellcome to CodeValue Backgammon 1986");
                Console.ForegroundColor = Color.Gray;
                Console.WriteLine("  |");
                Console.WriteLine("|                                          |");
                Console.WriteLine("|——————————————————————————————————————————|");
                Console.WriteLine();
                Console.WriteLine("Press any key to start");
                Console.ReadKey(true);
                Console.Clear();
                soundPlayer.Stop();
            }
        }

        private static void CloseGame()
        {
            using (var soundPlayer = new SoundPlayer(Resources.SoundLoop))
            {
                soundPlayer.LoadTimeout = 1000;
                soundPlayer.PlayLooping();
                Console.Clear();
                Console.WriteLine("|——————————————————————————————————————————|");
                Console.WriteLine("|                                          |");
                Console.Write("|                 ");
                Console.ForegroundColor = Color.White;
                Console.Write("GAME OVER");
                Console.ForegroundColor = Color.Gray;
                Console.WriteLine("                |");
                Console.WriteLine("|                                          |");
                Console.WriteLine("|——————————————————————————————————————————|");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey(true);
                Console.Clear();
                soundPlayer.Stop();
            }
        }
    }
}
