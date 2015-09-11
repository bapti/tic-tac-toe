using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Board;
using TicTacToe.Game.Player;

namespace TicTacToe.Game.ConsoleRenderer
{
    public class ConsoleRenderer
        : IGameRenderer
    {
        public void RenderResult(IGameResult gameResult)
        {
            if (gameResult.IsDraw)
            {
                Console.WriteLine("Game was a draw");
                Console.WriteLine("");
                return;
            }

            Console.WriteLine("Game won by {0}", gameResult.Winner.Name);
            Console.WriteLine("");
        }

        public void RenderBoard(ITicTacToeBoard ticTacToeBoard)
        {
            var cells = ticTacToeBoard.Cells();
            Console.WriteLine(" {0} | {1} | {2} ", cells[0, 0].ToConsoleString(), cells[0, 1].ToConsoleString(), cells[0, 2].ToConsoleString());
            Console.WriteLine(" {0} | {1} | {2} ", cells[1, 0].ToConsoleString(), cells[1, 1].ToConsoleString(), cells[1, 2].ToConsoleString());
            Console.WriteLine(" {0} | {1} | {2} ", cells[2, 0].ToConsoleString(), cells[2, 1].ToConsoleString(), cells[2, 2].ToConsoleString());
            Console.WriteLine("");
        }

        public void RenderStart(ITicTacToePlayer player1, ITicTacToePlayer player2, ITicTacToeBoard ticTacToeBoard)
        {
            Console.WriteLine("");
            Console.WriteLine("New game started");
            Console.WriteLine("Player 1 is {0} and playing {1}", player1.Name, player1.Piece.ToConsoleString());
            Console.WriteLine("Player 2 is {0} and playing {1}", player2.Name, player2.Piece.ToConsoleString());
            Console.WriteLine("");
            RenderBoard(ticTacToeBoard);
        }
    }

    public static class TicTacToePieceExtensions
    {
        public static string ToConsoleString(this TicTacToePiece piece)
        {
            switch (piece)
            {
                case TicTacToePiece.O:
                    return "O";
                case TicTacToePiece.X:
                    return "X";
                case TicTacToePiece.None:
                    return " ";
            }

            throw new Exception("Unknown piece type");
        }
    }
}
