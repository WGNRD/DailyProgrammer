using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    class Program
    {

        static void Main(string[] args)
        {
            #region properties
            Maze myMaze = new Maze();
            Player plyr = new Player();
            //Troll trl = new Troll(plyr);
            List<Troll> trls = new List<Troll>();

            Random rnd = new Random();
            ConsoleKey pressed;
            #endregion
            for (int i = 0; i < 3; i++)
            {
                trls.Add(new Troll(plyr, rnd));
            }

            do
            {
                Draw.DrawMaze(myMaze, plyr, trls);

                pressed = Console.ReadKey().Key;

                foreach (Troll trl in trls)
                {
                    trl.Move(plyr.locationX, plyr.locationY);

                }

                
                plyr.Move(pressed);

                Console.Clear();
            } while (!Draw.mazeExited);

            Console.WriteLine("Fin");
            Console.ReadKey();
        }
    }
}
