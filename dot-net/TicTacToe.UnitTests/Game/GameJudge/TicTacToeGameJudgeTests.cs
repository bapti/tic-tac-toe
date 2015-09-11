using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using TicTacToe.Game.Board;
using TicTacToe.Game.Judge;
using TicTacToe.Game.Player;
using Xunit;

namespace TicTacToe.UnitTests.Game.GameJudge
{
    public class TicTacToeGameJudgeTests
    {
        public TicTacToeGameJudge Sut { get; set; }
        public ITicTacToeBoard Board { get;set; }

        public TicTacToeGameJudgeTests()
        {
            Board = Substitute.For<ITicTacToeBoard>();
            Sut = new TicTacToeGameJudge();
        }

        public class GetGameResult : TicTacToeGameJudgeTests
        {
            private readonly ITicTacToePlayer _player1;
            private readonly ITicTacToePlayer _player2;

            public GetGameResult()
            {
                _player1 = Substitute.For<ITicTacToePlayer>();
                _player1.Piece.Returns(TicTacToePiece.O);
                _player2 = Substitute.For<ITicTacToePlayer>();
                _player2.Piece.Returns(TicTacToePiece.X);
            }

            [Fact]
            public void Player2ShouldWin()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.X},
                    {TicTacToePiece.None, TicTacToePiece.X, TicTacToePiece.None},
                    {TicTacToePiece.X, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.GetGameResult(Board, _player1, _player2);

                result.Winner.Should().Be(_player2);
                result.Loser.Should().Be(_player1);
                result.IsDraw.Should().BeFalse();
            }

            [Fact]
            public void Player2ShouldLose()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.O, TicTacToePiece.O, TicTacToePiece.O},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.GetGameResult(Board, _player1, _player2);

                result.Winner.Should().Be(_player1);
                result.Loser.Should().Be(_player2);
                result.IsDraw.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeDraw()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.X, TicTacToePiece.O, TicTacToePiece.X},
                    {TicTacToePiece.X, TicTacToePiece.O, TicTacToePiece.X},
                    {TicTacToePiece.O, TicTacToePiece.X, TicTacToePiece.O}
                });

                var result = Sut.GetGameResult(Board, _player1, _player2);

                result.IsDraw.Should().BeTrue();
            }
        }

        public class IsGameInPlay : TicTacToeGameJudgeTests
        {
            [Fact]
            public void ShouldBeTrueIfNoMovesMade()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeTrue();
            }

            [Fact]
            public void ShouldBeFalseIfDraw()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.X, TicTacToePiece.O, TicTacToePiece.X},
                    {TicTacToePiece.X, TicTacToePiece.O, TicTacToePiece.X},
                    {TicTacToePiece.O, TicTacToePiece.X, TicTacToePiece.O}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeFalseIfHorizontalWinRow0()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.X, TicTacToePiece.X, TicTacToePiece.X},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeFalseIfHorizontalWinRow1()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.X, TicTacToePiece.X, TicTacToePiece.X},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }
            [Fact]
            public void ShouldBeFalseIfHorizontalWinRow2()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.X, TicTacToePiece.X, TicTacToePiece.X}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeFalseIfVerticalWinCol0()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.O, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.O, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.O, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeFalseIfVerticalWinCol1()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }
            [Fact]
            public void ShouldBeFalseIfVerticalWinCol2()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.O},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.O},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.O}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }

            [Fact]
            public void ShouldBeFalseIfDiagonalWin()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.O, TicTacToePiece.None, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.O, TicTacToePiece.None},
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.O}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }
            
            [Fact]
            public void ShouldBeFalseIfDiagonalWin2()
            {
                Board.Cells().Returns(new[,]
                {
                    {TicTacToePiece.None, TicTacToePiece.None, TicTacToePiece.X},
                    {TicTacToePiece.None, TicTacToePiece.X, TicTacToePiece.None},
                    {TicTacToePiece.X, TicTacToePiece.None, TicTacToePiece.None}
                });

                var result = Sut.IsGameInPlay(Board);

                result.Should().BeFalse();
            }
        }
    }
}
