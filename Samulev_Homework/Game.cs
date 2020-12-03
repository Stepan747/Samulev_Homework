using System;

namespace Samulev_ThePrincess
{
    class Game
    {
        private Map map;
        private Player player;
        public static string GameResult = null;

        const string RestartGame = "Do you wont restart?";

        public Game()
        {
            map = new Map();
            player = new Player();
            GameResult = null;
        }

        public void StartGame()
        {
            while(GameResult == null)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        player.CoordinateVertical = 1;                       
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        player.CoordinateVertical = -1;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        player.CoordinateHorizontal = -1;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        player.CoordinateHorizontal = +1;
                        break;                      
                }

                Console.Clear();
                map.PaintMap(player);
            }

            Console.WriteLine(GameResult + RestartGame);
        }

        public static void CheckPosition(Player player, ref string cell)
        {
            if (player.CoordinateHorizontal == 9 && player.CoordinateVertical == 9)
            {
                Game.GameResult = "!!!You WIN!!!";
            }
            else if (cell != "0")
            {
                player.HP -= Convert.ToInt32(cell);

                if (player.HP < 1)
                {
                    Game.GameResult = "You lose, fucking asshole.";
                }

                cell = "0";
            }
        }
    }
}
