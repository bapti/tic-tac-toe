using TicTacToe.Game.Board;
using TicTacToe.Game.Player;

namespace TicTacToe.Game.Judge
{
    public interface IGameJudge
    {
        bool IsGameInPlay(ITicTacToeBoard ticTacToeBoard);
        IGameResult GetGameResult(ITicTacToeBoard ticTacToeBoard, ITicTacToePlayer player1, ITicTacToePlayer player2);
    }
}