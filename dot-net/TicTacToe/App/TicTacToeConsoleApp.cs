using System;
using TicTacToe.Game;

namespace TicTacToe.App
{
    public class TicTacToeConsoleApp
    {
        private readonly IGame game;

        public TicTacToeConsoleApp(
            IGame game
            )
        {
            this.game = game;
        }

        public void Start()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Welcome to tic tac toe");
            Console.WriteLine("");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();


            while (true)
            {
                game.PlayRound();

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press any key to play another round or Escape to exit");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
