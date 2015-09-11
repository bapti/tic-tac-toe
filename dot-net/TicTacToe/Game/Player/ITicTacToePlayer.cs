using TicTacToe.Game.Board;

namespace TicTacToe.Game.Player
{
    public interface ITicTacToePlayer
    {
        TicTacToePiece Piece { get; }
        void TakeTurn(ITicTacToeBoard ticTacToeBoard);
    }
}