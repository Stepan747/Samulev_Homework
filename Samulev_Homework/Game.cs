using System;

namespace Samulev_ThePrincess
{
    public class Game
    {
        private Map map;
        private Player player;
        public static string gameResult = null;

        private const string restartGame = "Do you wont restart?";
        private const string zero = "0";
        private const string statusWin = "!!!You WIN!!!";
        private const string statusLose = "You lose!";

        public Game()
        {
            map = new Map();
            player = new Player();
            gameResult = null;
        }

        public void StartGame()
        {
            while(gameResult == null)
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
                    default:
                        break;
                }

                Console.Clear();
                map.PaintMap(player);
            }

            Console.WriteLine(gameResult + restartGame);
        }

        public static void CheckPosition(Player player, ref string cell)
        {
            if (player.CoordinateHorizontal == 9 && player.CoordinateVertical == 9)
            {
                Game.gameResult = statusWin;
            }
            else if (cell != zero)
            {
                player.HP -= Convert.ToInt32(cell);

                if (player.HP < 1)
                {
                    Game.gameResult = statusLose;
                }

                cell = zero;
            }
        }
    }
}
