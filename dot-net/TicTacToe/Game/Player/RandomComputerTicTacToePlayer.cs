using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using TicTacToe.Game.Board;
using TicTacToe.Game.Utils;

namespace TicTacToe.Game.Player
{
    public class RandomComputerTicTacToePlayer 
        : ITicTacToePlayer
    {
        private readonly TicTacToePiece _piece;
        private readonly IRandomNumberPicker _numberPicker;
        private readonly string _name;

        public RandomComputerTicTacToePlayer(
            TicTacToePiece piece,
            IRandomNumberPicker numberPicker,
            string name
            )
        {
            _piece = piece;
            _numberPicker = numberPicker;
            Name = name;
        }

        public string Name { get; private set; }
        public TicTacToePiece Piece { get { return _piece; } }

        public void TakeTurn(ITicTacToeBoard ticTacToeBoard)
        {
            TicTacToePiece[,] cells = ticTacToeBoard.Cells();

            Tuple<int,int> cell = PickMove(cells);

            ticTacToeBoard.AddPieceToBoard(_piece, cell.Item1, cell.Item2);
        }

        private Tuple<int, int> PickMove(TicTacToePiece[,] cells)
        {
            var availableMoves = new List<Tuple<int,int>>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j] == TicTacToePiece.None)
                    {
                        availableMoves.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            if (availableMoves.Count == 0)
            {
                throw new Exception("No available moves");
            }

            var num = _numberPicker.Pick(1, availableMoves.Count);
            return availableMoves[num-1];
        }
    }
}
