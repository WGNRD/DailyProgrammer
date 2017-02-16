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
            Troll trl = new Troll(plyr);
            ConsoleKey pressed;
            #endregion

            do
            {
                Draw.DrawMaze(myMaze, plyr, trl);

                pressed = Console.ReadKey().Key;
                if (trl.alive)
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
