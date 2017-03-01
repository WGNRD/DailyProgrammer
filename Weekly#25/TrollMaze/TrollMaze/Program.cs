using System;
using System.Collections.Generic;

namespace TrollMaze
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region properties

            Maze myMaze = new Maze();
            Player plyr = new Player();
            //Troll trl = new Troll(plyr);
            List<Troll> trls = new List<Troll>();

            Random rnd = new Random();
            ConsoleKey pressed;

            #endregion properties

            for (int i = 0; i < 3; i++)
            {
                trls.Add(new Troll(plyr, rnd));
            }

            do
            {
                foreach (Troll trl in trls)
                {
                    trl.Move(plyr.locationX, plyr.locationY);
                }


                Console.Clear();
                Draw.DrawMazeLimitedSight(plyr, trls, 5);

                pressed = Console.ReadKey().Key;

                plyr.Move(pressed);

            } while (!Draw.mazeExited);

            Console.WriteLine("Fin");
            Console.ReadKey();
        }
    }
}