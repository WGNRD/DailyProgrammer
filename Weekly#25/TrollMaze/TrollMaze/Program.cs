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
            Player plyr = new Player(myMaze);
            Troll trl = new Troll(myMaze, plyr);
            ConsoleKey pressed;
            #endregion

            do
            {
                Draw.DrawMaze(myMaze, plyr, trl);

                pressed = Console.ReadKey().Key;
                plyr.Move(pressed, myMaze);
                trl.Move(myMaze, plyr.locationX, plyr.locationY);

                Console.Clear();
            } while (!Draw.mazeExited);

            Console.WriteLine("Fin");
            Console.ReadKey();
        }
    }
}
