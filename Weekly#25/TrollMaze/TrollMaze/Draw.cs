using System;
using System.Collections.Generic;

namespace TrollMaze
{
    internal static class Draw
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
            char[] chars = Maze.field[plyr.locationY].ToCharArray();
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

        /// <summary>
        /// Draws Maze with player and a list of Trolls on it
        /// </summary>
        /// <param name="plyr"></param>
        /// <param name="trls"></param>
        public static void DrawMaze(Player plyr, List<Troll> trls)
        {
            // Working with a copy of the maze, to place the figures on
            List<String> tempmz = placeFigures(plyr, trls);

            foreach (String line in tempmz)
            {
                Console.WriteLine(line);
            }
        }

        public static void DrawMazeLimitedSight(Player plyr, List<Troll> trls, int playerSight)
        {
            char[] chars;
            List<String> tempmz = placeFigures(plyr, trls);

            // Go through every line
            for (int lineIndex = 0; lineIndex < Maze.height; lineIndex++)
            {
                chars = tempmz[lineIndex].ToCharArray();
                //Go through every row
                for (int rowIndex = 0; rowIndex < Maze.width; rowIndex++)
                {
                    // If the row is not in the player sight, set it to space
                    if (rowIndex >= plyr.locationX + playerSight || rowIndex <= plyr.locationX - playerSight)
                    {
                        chars[rowIndex] = ' ';
                    }
                }
                tempmz[lineIndex] = new string(chars);

                // Cut out all the lines
                if (lineIndex >= plyr.locationY + playerSight || lineIndex <= plyr.locationY - playerSight)
                {
                    tempmz[lineIndex] = "";
                }
            }

            foreach (String line in tempmz)
            {
                Console.WriteLine(line);
            }
        }

        private static List<String> placeFigures(Player plyr, List<Troll> trls)
        {
            List<String> tempmz = new List<string>();
            char[] chars = null;

            tempmz.AddRange(Maze.field);

            chars = tempmz[plyr.locationY].ToCharArray();
            chars[plyr.locationX] = plyr.direction;
            tempmz[plyr.locationY] = new string(chars);

            foreach (Troll trl in trls)
            {
                chars = tempmz[trl.coordY].ToCharArray();
                chars[trl.coordX] = trl.representation;
                tempmz[trl.coordY] = new string(chars);
            }

            return tempmz;
        }
    }
}