using System;

namespace Samulev_ThePrincess
{
    class Map
    {
        private const string princess = "G";
        private const string Player = "B";
        private const string emptyCell = "-";
        private const string inactiveBomb = "*";

        public const byte mapHorizontal = 10;
        public const byte mapVertical = 10;
        public const byte countBomb = 10;

        string[][] cellMap;

        public Map()
        {
            cellMap = new string[mapVertical][];

            for(byte row = 0; row < mapVertical; row++)
            {
                cellMap[row] = new string[mapHorizontal];
            }

            Random random = new Random();
            byte bombPosition;

            for(byte bomb = 0; bomb < countBomb; bomb++)
            {
                bombPosition = (byte)random.Next(1, (mapVertical * mapHorizontal) - 2);
                cellMap[bombPosition / mapVertical][bombPosition % mapHorizontal] = random.Next(1, 10).ToString();
            }

            cellMap[mapVertical - 1][mapHorizontal - 1] = princess;
        }

       public void PaintMap(Player player)
        {
            int damage;

            for (byte row = 0; row < mapHorizontal; row++)
            {
                for (byte colunm = 0; colunm < mapVertical; colunm++)
                {
                    if(player.CoordinateVertical == row && player.CoordinateHorizontal == colunm)
                    {
                        Console.Write(Player);

                        if (cellMap[row][colunm] != null)
                        {
                            Game.CheckPosition(player, ref cellMap[row][colunm]);
                        }
                    }
                    else if(cellMap[row][colunm] == null)
                    {
                        Console.Write(emptyCell);
                    }
                    else
                    {
                        if(int.TryParse(cellMap[row][colunm], out damage))
                        {
                            if(damage != 0)
                            {
                                Console.Write(emptyCell);
                            }
                            else
                            {
                                Console.Write(inactiveBomb);
                            }
                        }
                        else
                        {
                             Console.Write(cellMap[row][colunm]);
                        }
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"HP: {player.HP}");
        }
    }
}
