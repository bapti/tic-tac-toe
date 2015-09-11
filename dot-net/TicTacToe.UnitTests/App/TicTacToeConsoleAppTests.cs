using System;
using FluentAssertions;
using TicTacToe.App;
using Xunit;

namespace TicTacToe.UnitTests.App
{
    public class TicTacToeConsoleAppTests
    {
        public TicTacToeConsoleApp Sut { get; private set; }

        public TicTacToeConsoleAppTests()
        {
            Sut = new TicTacToeConsoleApp();
        }
        
        public class Start : TicTacToeConsoleAppTests
        {
            [Fact]
            public void Should_Throw_Not_Implemented()
            {
                Action a = () => Sut.Start();

                a.ShouldThrow<NotImplementedException>();
            }
        }
    }
}
