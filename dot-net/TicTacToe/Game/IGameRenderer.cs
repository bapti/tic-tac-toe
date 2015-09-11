using TicTacToe.Game.Board;
using TicTacToe.Game.Player;

namespace TicTacToe.Game
{
    public interface IGameRenderer
    {
        void RenderResult(IGameResult gameResult);
        void RenderBoard(ITicTacToeBoard ticTacToeBoard);
        void RenderStart(ITicTacToePlayer player1, ITicTacToePlayer player2, ITicTacToeBoard ticTacToeBoard);
    }
}