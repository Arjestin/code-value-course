namespace Backgammon.Framework.Interfaces
{
    public interface IBoard
    {
        IPoint[] Points { get; set; }
        void Display();
    }
}
