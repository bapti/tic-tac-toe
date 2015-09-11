using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TicTacToe.Game.Board;
using Xunit;

namespace TicTacToe.UnitTests.Game.Board
{
    public class TicTacToeGameBoardTests
    {
        public TicTacToeBoard Sut { get; set; }

        public TicTacToeGameBoardTests()
        {
            Sut = new TicTacToeBoard();
        }

        [Fact]
        public void BoardShouldBeEmpty()
        {
            var cells = Sut.Cells();

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    cells[i, j].Should().Be(TicTacToePiece.None);
                }
            }
        }

        public class Cells : TicTacToeGameBoardTests
        {
            [Fact]
            public void CellsCopiesTheBoard()
            {
                Sut.AddPieceToBoard(TicTacToePiece.O, 0, 0);
                var cells = Sut.Cells();

                Sut.Reset();

                cells[0,0].Should().Be(TicTacToePiece.O);
            }
        }

        public class AddPieceToBoard : TicTacToeGameBoardTests
        {
            [Fact]
            public void ShouldAddPieceToCorrectPlace()
            {
                Sut.Cells()[1, 1].Should().Be(TicTacToePiece.None);

                Sut.AddPieceToBoard(TicTacToePiece.O, 1, 1);

                Sut.Cells()[1, 1].Should().Be(TicTacToePiece.O);
            }

            [Fact]
            public void ShouldThrowOnHighX()
            {
                Action a = () => Sut.AddPieceToBoard(TicTacToePiece.O, 3, 1);

                a.ShouldThrow<ArgumentException>();
            }

            [Fact]
            public void ShouldThrowOnLowX()
            {
                Action a = () => Sut.AddPieceToBoard(TicTacToePiece.O, -1, 1);

                a.ShouldThrow<ArgumentException>();
            }

            [Fact]
            public void ShouldThrowOnHighY()
            {
                Action a = () => Sut.AddPieceToBoard(TicTacToePiece.O, 1, 3);

                a.ShouldThrow<ArgumentException>();
            }

            [Fact]
            public void ShouldThrowOnLowY()
            {
                Action a = () => Sut.AddPieceToBoard(TicTacToePiece.O, 1, -1);

                a.ShouldThrow<ArgumentException>();
            }

            [Fact]
            public void ShouldThrowOnPieceNone()
            {
                Action a = () => Sut.AddPieceToBoard(TicTacToePiece.None, 1, 1);

                a.ShouldThrow<ArgumentException>();
            }
        }

        public class Reset : TicTacToeGameBoardTests
        {
            [Fact]
            public void Reset_should_reset_the_board()
            {
                Sut.AddPieceToBoard(TicTacToePiece.O, 0, 0);
                Sut.Reset();

                var cells = Sut.Cells();

                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        cells[i, j].Should().Be(TicTacToePiece.None);
                    }
                }
            }
        }
    }
}
