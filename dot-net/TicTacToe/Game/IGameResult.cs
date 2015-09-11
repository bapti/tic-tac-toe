using TicTacToe.Game.Player;

namespace TicTacToe.Game
{
    public interface IGameResult
    {
        bool IsDraw { get; }
        ITicTacToePlayer Winner { get; }
        ITicTacToePlayer Loser { get; }
    }
}