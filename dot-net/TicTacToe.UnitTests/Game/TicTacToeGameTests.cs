using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TicTacToe.Game;
using Xunit;

namespace TicTacToe.UnitTests.Game
{
    public class TicTacToeGameTests
    {
        public TicTacToeGame Sut { get; set; }

        public TicTacToeGameTests()
        {
            Sut = new TicTacToeGame();
        }

        public class PlayGame : TicTacToeGameTests
        {
            [Fact]
            public void Should_Throw_Not_Implemented_Exception()
            {
                Action a = () => Sut.PlayRound();

                a.ShouldThrow<NotImplementedException>();
            }
        }
    }
}
