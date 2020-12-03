using System;

namespace Samulev_ThePrincess
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;

            string restartGame = "y";

            while (restartGame.ToLower() == "y")
            {
                game = new Game();
                game.StartGame();

                restartGame = Console.ReadLine();
            }
        }
    }
}
