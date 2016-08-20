using Backgammon.Framework.Enumerations;

namespace Backgammon.Framework.Interfaces
{
    public interface IArrow
    {
        IPosition Position { get; }
        Direction Direction { get; }
        void Display();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void SelectChecker();
        bool MoveChecker();
        void ReleaseChecker();
    }
}
