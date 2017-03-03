using System;
using System.Collections.Generic;

namespace TrollMaze
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region properties
            int trollCount;
            string yn;
            int viewRadius = 0;
            Maze myMaze = new Maze();
            Player plyr = new Player();
            //Troll trl = new Troll(plyr);
            List<Troll> trls = new List<Troll>();

            Random rnd = new Random();

            #endregion properties

            viewRadius = GetMetaInfoFromPlayer(out trollCount, out yn, viewRadius);

            for (int i = 0; i < trollCount; i++)
            {
                trls.Add(new Troll(plyr, rnd));
            }

            if (yn == "y")
            {
                playFullSight(plyr, trls); 
            }
            else
            {
                playLimitedSight(plyr, trls, viewRadius); 
            }

            Console.Clear();
            Console.WriteLine("Fin");
            Console.ReadKey();
        }

        private static void playFullSight(Player plyr, List<Troll> trls)
        {
            ConsoleKey pressed;
            do
            {
                foreach (Troll trl in trls)
                {
                    trl.Move(plyr.locationX, plyr.locationY);
                }


                Console.Clear();
                Draw.DrawMaze(plyr, trls);
                pressed = Console.ReadKey().Key;
                plyr.Move(pressed);

            } while (!Draw.mazeExited);

        }

        private static void playLimitedSight(Player plyr, List<Troll> trls, int playerSight)
        {
            ConsoleKey pressed;
            do
            {
                foreach (Troll trl in trls)
                {
                    trl.Move(plyr.locationX, plyr.locationY);
                }


                Console.Clear();
                Draw.DrawMazeLimitedSight(plyr, trls, playerSight);
                pressed = Console.ReadKey().Key;

                plyr.Move(pressed);

            } while (!Draw.mazeExited);
        }

        /// <summary>
        /// Gets infos from player
        /// </summary>
        /// <param name="trollCount"></param>
        /// <param name="yn"></param>
        /// <param name="viewRadius"></param>
        /// <returns></returns>
        private static int GetMetaInfoFromPlayer(out int trollCount, out string yn, int viewRadius)
        {
            do
            {
                Console.WriteLine("How many trolls?(recommended between 1 & 20): ");
            } while (!Int32.TryParse(Console.ReadLine(), out trollCount));

            do
            {
                Console.WriteLine("Wanna see entire maze?(y/n): ");
                yn = Console.ReadLine();
            } while (!"YyNn".Contains(yn));

            if (yn == "Y")
            {
                do
                {
                    Console.WriteLine("How far do u wanna see?(recommended between 4 & 10): ");

                } while (!Int32.TryParse(Console.ReadLine(), out viewRadius));
            }

            return viewRadius;
        }

    }
}