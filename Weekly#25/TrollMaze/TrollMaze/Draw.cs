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
        /// <param name="Maze"> Get the maze </param>
        /// <param name="plyr"> Get the player</param>
        public static void DrawMaze(Maze mz, Player plyr)
        {
            int count = 0;
            char [] chars = Maze.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;
            
            foreach (String line in Maze.field)
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

        /// <summary>
        /// Draws Maze with player and 1 Troll on it
        /// </summary>
        /// <param name="mz"></param>
        /// <param name="plyr"></param>
        /// <param name="trl"></param>
        public static void DrawMaze(Maze mz, Player plyr, Troll trl)
        {
            int count = 0;
            char[] chars = Maze.field[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;


            char[] trlchars = Maze.field[trl.coordY].ToCharArray();
            trlchars[trl.coordX] = '@';

            if (plyr.locationY == trl.coordY)
            {
                chars[trl.coordX] = '@';
                chars[plyr.locationX] = plyr.direction;
            }

            foreach (String line in Maze.field)
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

        // TODO: Make Draw func with takes a list of trolls

        public static void DrawMaze(Maze mz, Player plyr, List<Troll> trls)
        {
            List<char[]> trlcharList = new List<char[]>();
            List<String> temp;
            int count = 0;
            bool playerInCharList = false;
            char[] chars = null;
            

            foreach (String line in Maze.field)
            {
                if (count == plyr.locationY && !playerInCharList)
                {
                    Console.WriteLine(new string(chars));
                }else if (mytrls.Exists(t => t.coordY == count))
                {
                    Console.WriteLine(new string(trlcharList[0]));
                    trlcharList.RemoveAt(0);
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
