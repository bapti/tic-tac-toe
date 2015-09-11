using System;
using FluentAssertions;
using NSubstitute;
using TicTacToe.Game;
using TicTacToe.Game.Board;
using TicTacToe.Game.Judge;
using TicTacToe.Game.Player;
using Xunit;

namespace TicTacToe.UnitTests.Game
{
    public class TicTacToeGameTests
    {
        public TicTacToeGame Sut { get; set; }
        public ITicTacToeBoard TicTacToeBoard;
        public ITicTacToePlayer Player1;
        public ITicTacToePlayer Player2;
        public IGameJudge GameJudge;
        public IGameRenderer GameRenderer;

        public TicTacToeGameTests()
        {
            TicTacToeBoard = Substitute.For<ITicTacToeBoard>();
            Player1 = Substitute.For<ITicTacToePlayer>();
            Player2 = Substitute.For<ITicTacToePlayer>();
            GameJudge = Substitute.For<IGameJudge>();
            GameRenderer = Substitute.For<IGameRenderer>();

            Sut = new TicTacToeGame(
                TicTacToeBoard,Player1,Player2,GameJudge,GameRenderer
                );
        }

        public class PlayGame : TicTacToeGameTests
        {
            [Fact]
            public void Board_Should_Be_Reset()
            {
                Sut.Play();

                TicTacToeBoard.Received(1).Reset();
            }

            [Fact]
            public void Player1ShouldBeChosenFirst()
            {
                GameJudge.IsGameInPlay(TicTacToeBoard).Returns(true, false);

                Sut.Play();

                Player1.Received(1).TakeTurn(TicTacToeBoard);
                Player2.Received(0).TakeTurn(TicTacToeBoard);
            }

            [Fact]
            public void Player2ShouldBeChosenSecond()
            {
                GameJudge.IsGameInPlay(TicTacToeBoard).Returns(true, true, false);

                Sut.Play();

                Player1.Received(1).TakeTurn(TicTacToeBoard);
                Player2.Received(1).TakeTurn(TicTacToeBoard);
            }

            [Fact]
            public void EachPlayerShouldPlayTwice()
            {
                GameJudge.IsGameInPlay(TicTacToeBoard).Returns(true, true, true, true, false);

                Sut.Play();

                Player1.Received(2).TakeTurn(TicTacToeBoard);
                Player2.Received(2).TakeTurn(TicTacToeBoard);
            }
        }
    }
}
