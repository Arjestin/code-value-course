namespace Backgammon.Framework.Interfaces
{
    public interface IGame
    {
        bool SwitchPlayer { get; }
        void RollDice();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SelectChecker();
        void MoveChecker();
        void ReleaseChecker();
        void PassTurn();
        void Display();
    }
}
