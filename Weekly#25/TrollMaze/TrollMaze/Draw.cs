using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    static class Draw
    {
        // TODO write in static extra-class
        public static bool mazeExited = false;
        /// <summary>
        /// Draws the maze with the player on it
        /// </summary>
        /// <param name="mz"> Get the maze </param>
        /// <param name="plyr"> Get the player</param>
        public static void DrawMaze(Maze mz, Player plyr)
        {
            int count = 0;
            char [] chars = mz.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;
            
            foreach (String line in mz.field)
            { 
                if (count == plyr.locationY)
                {
                    Console.WriteLine(new string(chars));
                }
                else
                {
                    Console.WriteLine(line);
                }

                count++;
            }
        }

        public static void DrawMaze(Maze mz, Player plyr, Troll trl)
        {
            int count = 0;
            char[] chars = mz.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;

            char[] trlchars = mz.field[trl.coordY].ToCharArray();
            trlchars[trl.coordX] = '@';

            if (plyr.locationY == trl.coordY)
            {

                chars[trl.coordX] = '@';
                chars[plyr.locationX] = plyr.direction;
            }

            foreach (String line in mz.field)
            {
                if (count == plyr.locationY)
                {
                    Console.WriteLine(new string(chars));
                }
                else if (count == trl.coordY)
                {
                    Console.WriteLine(new string(trlchars));
                }
                else
                {
                    Console.WriteLine(line);
                }

                count++;
            }
        }
    }
}
