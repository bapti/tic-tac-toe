namespace TicTacToe.Game
{
    public interface IGameResult
    {
        bool IsDraw { get; }
        IPlayer Winner { get; }
        IPlayer Loser { get; }
    }
}