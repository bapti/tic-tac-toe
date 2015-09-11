using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game.Board
{
    public enum TicTacToePiece
    {
        None,
        X,
        O
    }

    public interface ITicTacToeBoard
    {
        void Reset();
        void AddPieceToBoard(TicTacToePiece piece, int x, int y);
        TicTacToePiece[,] Cells();
    }

    public class TicTacToeBoard 
        : ITicTacToeBoard
    {
        private TicTacToePiece[,] _cells = new TicTacToePiece[3,3];


        public void Reset()
        {
            _cells = new TicTacToePiece[3,3];
        }

        public void AddPieceToBoard(TicTacToePiece piece, int x, int y)
        {
            if (x > 2 || x < 0)
            {
                throw new ArgumentException("X value must be between 0 and 2");
            }

            if (y > 2 || y < 0)
            {
                throw new ArgumentException("X value must be between 0 and 2");
            }

            if (piece == TicTacToePiece.None)
            {
                throw new ArgumentException("Piece must be either x or o");
            }

            _cells[x,y] = piece;
        }

        public TicTacToePiece[,] Cells()
        {
            var result = new TicTacToePiece[3, 3];

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    result[i, j] = _cells[i, j];
                }
            }
            
            return result;
        }
    }
}
