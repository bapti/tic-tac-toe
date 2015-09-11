using TicTacToe.App;
using TicTacToe.Game;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleApp = new TicTacToeConsoleApp(
                new TicTacToeGame()
                );
            consoleApp.Start();
        }
    }
}
