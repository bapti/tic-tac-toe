using System;
using FluentAssertions;
using NSubstitute;
using TicTacToe.Game;
using Xunit;

namespace TicTacToe.UnitTests.Game
{
    public class TicTacToeGameTests
    {
        public TicTacToeGame Sut { get; set; }
        public IBoard Board;
        public IPlayer Player1;
        public IPlayer Player2;
        public IGameJudge GameJudge;
        public IGameRenderer GameRenderer;

        public TicTacToeGameTests()
        {
            Board = Substitute.For<IBoard>();
            Player1 = Substitute.For<IPlayer>();
            Player2 = Substitute.For<IPlayer>();
            GameJudge = Substitute.For<IGameJudge>();
            GameRenderer = Substitute.For<IGameRenderer>();

            Sut = new TicTacToeGame(
                Board,Player1,Player2,GameJudge,GameRenderer
                );
        }

        public class PlayGame : TicTacToeGameTests
        {
            [Fact]
            public void Board_Should_Be_Reset()
            {
                Sut.Play();

                Board.Received(1).Reset();
            }

            [Fact]
            public void Player1ShouldBeChosenFirst()
            {
                GameJudge.IsGameInPlay(Board).Returns(true, false);

                Sut.Play();

                Player1.Received(1).TakeTurn(Board);
                Player2.Received(0).TakeTurn(Board);
            }

            [Fact]
            public void Player2ShouldBeChosenSecond()
            {
                GameJudge.IsGameInPlay(Board).Returns(true, true, false);

                Sut.Play();

                Player1.Received(1).TakeTurn(Board);
                Player2.Received(1).TakeTurn(Board);
            }

            [Fact]
            public void EachPlayerShouldPlayTwice()
            {
                GameJudge.IsGameInPlay(Board).Returns(true, true, true, true, false);

                Sut.Play();

                Player1.Received(2).TakeTurn(Board);
                Player2.Received(2).TakeTurn(Board);
            }
        }
    }
}
