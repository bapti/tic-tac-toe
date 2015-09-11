using TicTacToe.Game.Player;

namespace TicTacToe.Game
{
    public interface IGameResult
    {
        bool IsDraw { get; }
        ITicTacToePlayer Winner { get; }
        ITicTacToePlayer Loser { get; }
    }

    public class TicTacToeGameResult
        : IGameResult
    {
        public bool IsDraw { get; set; }
        public ITicTacToePlayer Winner { get; set; }
        public ITicTacToePlayer Loser { get; set; }
    }
}