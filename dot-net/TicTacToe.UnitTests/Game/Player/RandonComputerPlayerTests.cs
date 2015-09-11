using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.SqlServer.Server;
using NSubstitute;
using TicTacToe.Game.Board;
using TicTacToe.Game.Player;
using TicTacToe.Game.Utils;
using Xunit;

namespace TicTacToe.UnitTests.Game.Player
{
    public class RandonComputerPlayerTests
    {
        public RandomComputerTicTacToePlayer Sut { get; set; }
        public ITicTacToeBoard Board { get; set; }
        public IRandomNumberPicker NumberPicker { get; set; }

        public RandonComputerPlayerTests()
        {
            Board = Substitute.For<ITicTacToeBoard>();
            NumberPicker = Substitute.For<IRandomNumberPicker>();
            Sut = new RandomComputerTicTacToePlayer(TicTacToePiece.O, NumberPicker, "Jim");

            Board.Cells().Returns(new TicTacToePiece[3, 3]);

            NumberPicker.Pick(0,0).ReturnsForAnyArgs(1);
        }


        public class TakeTurn : RandonComputerPlayerTests
        {
            [Fact]
            public void ShouldPlaceOnePieceOnTheBoard()
            {
                Sut.TakeTurn(Board);

                Board.ReceivedWithAnyArgs(1).AddPieceToBoard(TicTacToePiece.O, 0, 0);
            }

            [Fact]
            public void ShouldThrowWhenNoMovesAreLeft()
            {
                Board.Cells().Returns(new TicTacToePiece[3, 3]
                {
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O}
                });

                Action a = () => Sut.TakeTurn(Board);

                a.ShouldThrow<Exception>();
            }

            [Fact]
            public void ShouldReturnX2Y2()
            {
                Board.Cells().Returns(new TicTacToePiece[3, 3]
                {
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.None}
                });

                Sut.TakeTurn(Board);

                Board.Received(1).AddPieceToBoard(TicTacToePiece.O, 2, 2);
            }

            [Fact]
            public void ShouldReturnX0Y0()
            {
                Board.Cells().Returns(new TicTacToePiece[3, 3]
                {
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O}
                });

                Sut.TakeTurn(Board);

                Board.Received(1).AddPieceToBoard(TicTacToePiece.O, 0, 0);
            }

            [Fact]
            public void ShouldReturnX0Y2()
            {
                Board.Cells().Returns(new TicTacToePiece[3, 3]
                {
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.None},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O}
                });

                Sut.TakeTurn(Board);

                Board.Received(1).AddPieceToBoard(TicTacToePiece.O, 0, 2);
            }

            [Fact]
            public void ShouldReturnX2Y0()
            {
                Board.Cells().Returns(new TicTacToePiece[3, 3]
                {
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.O}
                });

                Sut.TakeTurn(Board);

                Board.Received(1).AddPieceToBoard(TicTacToePiece.O, 2, 0);
            }

            [Fact]
            public void ShouldWorkAgainstRealBoard()
            {
                var board = new TicTacToeBoard();
                NumberPicker.Pick(0, 0).ReturnsForAnyArgs(3);

                Sut.TakeTurn(board);

                var cells = board.Cells();
                cells[0, 2].Should().Be(TicTacToePiece.O);
            }
        }

        
    }
}
