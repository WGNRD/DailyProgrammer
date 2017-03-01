using System;
using System.Collections.Generic;
using System.Linq;

namespace TrollMaze
{
    internal class Maze
    {
        public static int height { get; set; }
        public static int width { get; set; }
        public static IList<String> field { get; set; }

        public Maze()
        {
            IList<String> maze = Initialize();

            height = maze.Count();
            width = maze[0].Length;
            field = maze;
        }

        /// <summary>
        /// Initialize the Maze for the player to walk in
        /// </summary>
        /// <returns> String with the Maze </returns>
        public static IList<String> Initialize()
        {
            IList<String> mazeField = new List<String>();

            //mazeField.Add("#   #");
            //mazeField.Add("# # #");
            //mazeField.Add("#   #");

            mazeField.Add("#######################################");
            mazeField.Add("#######################################");
            mazeField.Add("## #       #       #     #         # ##");
            mazeField.Add("## # ##### # ### ##### ### ### ### # ##");
            mazeField.Add("##       #   # #     #     # # #   # ##");
            mazeField.Add("###### # ##### ##### ### # # # ##### ##");
            mazeField.Add("##   # #       #     # # # # #     # ##");
            mazeField.Add("## # ####### # # ##### ### # ##### # ##");
            mazeField.Add("## #       # # #   #     #     #   # ##");
            mazeField.Add("## ####### ### ### # ### ##### # ### ##");
            mazeField.Add("##     #   # #   # #   #     # #     ##");
            mazeField.Add("## ### ### # ### # ##### # # # ########");
            mazeField.Add("##   #   # # #   #   #   # # #   #   ##");
            mazeField.Add("######## # # # ##### # ### # ### ### ##");
            mazeField.Add("##     # #     #   # #   # #   #     ##");
            mazeField.Add("## ### # ##### ### # ### ### ####### ##");
            mazeField.Add("## #   #     #     #   # # #       # ##");
            mazeField.Add("## # ##### # ### ##### # # ####### # ##");
            mazeField.Add("## #     # # # # #     #       # #   ##");
            mazeField.Add("## ##### # # # ### ##### ##### # ######");
            mazeField.Add("## #   # # #     #     # #   #       ##");
            mazeField.Add("## # ### ### ### ##### ### # ##### # ##");
            mazeField.Add("## #         #     #       #       # ##");
            mazeField.Add("##X####################################");
            mazeField.Add("#######################################");

            return mazeField;
        }

        /// <summary>
        /// Sets the Cell at X Y to the given Input
        /// </summary>
        /// <param name="X">X Coord where the Cell is</param>
        /// <param name="Y">Y Coord where the Cell is</param>
        /// <param name="input">Which char should be put in the Cell</param>
        /// <returns></returns>
        public static bool SetCell(int X, int Y, char input)
        {
            if (!isValidChar(input))
                return false;

            char[] chars = null;
            chars = field[Y].ToCharArray();
            chars[X] = input;
            field[Y] = new string(chars);

            return true;
        }

        /// <summary>
        /// Returns the Value of the Cell
        /// </summary>
        /// <param name="X">X Coord of the Cell</param>
        /// <param name="Y">Y Coord of the Cell</param>
        /// <returns></returns>
        public static char GetCell(int X, int Y)
        {
            return field[Y].ElementAt(X);
        }

        /// <summary>
        /// Checks if the char is allowed in the Cell
        /// </summary>
        /// <param name="input">Character to Check</param>
        /// <returns>True if allowed</returns>
        private static bool isValidChar(char input)
        {
            return " #@^<>v%".Contains(input.ToString());
        }
    }
}