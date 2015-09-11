using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TicTacToe.Game.Board;
using TicTacToe.Game.Player;

namespace TicTacToe.Game.Judge
{
    public class TicTacToeGameJudge
        : IGameJudge
    {
        public bool IsGameInPlay(ITicTacToeBoard ticTacToeBoard)
        {
            var cells = ticTacToeBoard.Cells();
            return AreCellsAvailable(cells)
                   && !IsWon(cells);
        }

        public IGameResult GetGameResult(
            ITicTacToeBoard ticTacToeBoard,
            ITicTacToePlayer player1,
            ITicTacToePlayer player2
            )
        {
            var cells = ticTacToeBoard.Cells();
            var diagonal = IsWinOnDiagonal(cells);
            if (diagonal != TicTacToePiece.None)
            {
                return new TicTacToeGameResult()
                {
                    IsDraw = false,
                    Winner = diagonal == player1.Piece ? player1 : player2,
                    Loser = diagonal == player1.Piece ? player2 : player1,
                };
            }

            var horizontal = IsWinOnHorizontal(cells);
            if (horizontal != TicTacToePiece.None)
            {
                return new TicTacToeGameResult()
                {
                    IsDraw = false,
                    Winner = horizontal == player1.Piece ? player1 : player2,
                    Loser = horizontal == player1.Piece ? player2 : player1,
                };
            }

            var vertical = IsWinOnHorizontal(cells);
            if (vertical != TicTacToePiece.None)
            {
                return new TicTacToeGameResult()
                {
                    IsDraw = false,
                    Winner = vertical == player1.Piece ? player1 : player2,
                    Loser = vertical == player1.Piece ? player2 : player1,
                };
            }

            if (IsDrawn(ticTacToeBoard))
            {
                return new TicTacToeGameResult()
                {
                    IsDraw = true
                };
            }
            
            throw new Exception("No valid result found");
        }

        private bool IsDrawn(ITicTacToeBoard ticTacToeBoard)
        {
            var cells = ticTacToeBoard.Cells();
            return !AreCellsAvailable(cells)
                   && !IsWon(cells);
        }

        private bool IsWon(TicTacToePiece[,] cells)
        {
            return !(IsWinOnDiagonal(cells) == TicTacToePiece.None
                   && IsWinOnVertical(cells) == TicTacToePiece.None
                   && IsWinOnHorizontal(cells) == TicTacToePiece.None);
        }

        private TicTacToePiece IsWinOnVertical(TicTacToePiece[,] cells)
        {
            if (IsWinOnVertical(cells, TicTacToePiece.O))
            {
                return TicTacToePiece.O;
            }

            if (IsWinOnVertical(cells, TicTacToePiece.X))
            {
                return TicTacToePiece.X;
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece IsWinOnHorizontal(TicTacToePiece[,] cells)
        {
            if (IsWinOnHorizontal(cells, TicTacToePiece.O))
            {
                return TicTacToePiece.O;
            }

            if (IsWinOnHorizontal(cells, TicTacToePiece.X))
            {
                return TicTacToePiece.X;
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece IsWinOnDiagonal(TicTacToePiece[,] cells)
        {
            if (IsWinOnDiagonal(cells, TicTacToePiece.O))
            {
                return TicTacToePiece.O;
            }

            if (IsWinOnDiagonal(cells, TicTacToePiece.X))
            {
                return TicTacToePiece.X;
            }

            return TicTacToePiece.None;
        }

        private bool IsWinOnHorizontal(TicTacToePiece[,] cells, TicTacToePiece piece)
        {
            return
                (cells[0, 0] == piece && cells[0, 1] == piece && cells[0, 2] == piece)
                || (cells[1, 0] == piece && cells[1, 1] == piece && cells[1, 2] == piece)
                || (cells[2, 0] == piece && cells[2, 1] == piece && cells[2, 2] == piece);

        }

        private bool IsWinOnVertical(TicTacToePiece[,] cells, TicTacToePiece piece)
        {
            return
                (cells[0, 0] == piece && cells[1, 0] == piece && cells[2, 0] == piece)
                || (cells[0, 1] == piece && cells[1, 1] == piece && cells[2, 1] == piece)
                || (cells[0, 2] == piece && cells[1, 2] == piece && cells[2, 2] == piece);

        }

        private bool IsWinOnDiagonal(TicTacToePiece[,] cells, TicTacToePiece piece)
        {
            return
                (cells[0, 0] == piece && cells[1, 1] == piece && cells[2, 2] == piece)
                || (cells[0, 2] == piece && cells[1, 1] == piece && cells[2, 0] == piece);

        }


        private bool AreCellsAvailable(TicTacToePiece[,] cells)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j] == TicTacToePiece.None)
                        return true;
                }
            }

            return false;
        }
    }
}