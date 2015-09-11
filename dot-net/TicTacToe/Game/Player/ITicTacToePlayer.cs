using TicTacToe.Game.Board;

namespace TicTacToe.Game.Player
{
    public interface ITicTacToePlayer
    {
        void TakeTurn(ITicTacToeBoard ticTacToeBoard);
    }
}