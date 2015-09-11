using TicTacToe.Game.Board;

namespace TicTacToe.Game.Player
{
    public interface ITicTacToePlayer
    {
        string Name { get; }
        TicTacToePiece Piece { get; }
        void TakeTurn(ITicTacToeBoard ticTacToeBoard);
    }
}