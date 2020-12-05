using System;
using System.Collections.Generic;
using System.Text;

namespace Samulev_ThePrincess
{
    public class Player
    {
        private int coordinateHorizontal;
        private int coordinateVertical;

        public int HP { get; set; }
        public int CoordinateHorizontal {
            get { return coordinateHorizontal; }
            set
            {
                if ((coordinateHorizontal + value) < Map.mapHorizontal &&
                    (coordinateHorizontal + value) >= 0) 
                {
                    coordinateHorizontal += value;
                }
            }
        }
        public int CoordinateVertical {
            get { return coordinateVertical; }
            set
            {
                if ((coordinateVertical + value) < Map.mapVertical &&
                    (coordinateVertical + value) >= 0)
                { 
                    coordinateVertical += value;
                }
            }
        }

        public  Player()
        {
            HP = 10;
            CoordinateHorizontal = 0;
            CoordinateVertical = 0;
        }

    }
}
