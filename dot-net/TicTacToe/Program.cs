using System;
using TicTacToe.App;
using TicTacToe.Game;
using TicTacToe.Game.Board;
using TicTacToe.Game.ConsoleRenderer;
using TicTacToe.Game.Judge;
using TicTacToe.Game.Player;
using TicTacToe.Game.Utils;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleApp = new TicTacToeConsoleApp(
                new TicTacToeGame(
                    new TicTacToeBoard(), 
                    new RandomComputerTicTacToePlayer(TicTacToePiece.O, new RandomNumberPicker(), "Phil"),
                    new RandomComputerTicTacToePlayer(TicTacToePiece.X, new RandomNumberPicker(), "Jeremy"),
                    new TicTacToeGameJudge(), 
                    new ConsoleRenderer(),
                    new GamePauser(new TimeSpan(0,0,0,1))
                    )
                );
            consoleApp.Start();
        }
    }
}
