using System;

namespace Samulev_ThePrincess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string beginGame = "Нажмите любую клавишу чтобы начать игру...";
            const string startAgain = "y";

            Console.WriteLine(beginGame);

            Game game;

            string restartGame = startAgain;

            while (restartGame.ToLower() == startAgain)
            {
                game = new Game();
                game.StartGame();

                restartGame = Console.ReadLine();
            }
        }
    }
}
