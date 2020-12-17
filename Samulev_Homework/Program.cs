using System;

namespace Samulev_Homework
{
    class Program
    {
        public static void Main(string[] args)
        {
            int personChoose;

            while (!(Int32.TryParse(Console.ReadLine(), out personChoose) && personChoose > 0)) ;

            switch (personChoose)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
               
            }
        }
    }
}
