using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    class Maze
    {
        public static int height { get; set; }
        public static int width { get; set; }
        public static IList<String> field { get; set; }

        public Maze()
        {
            IList<String> maze =  Initialize();

            height = maze.Count();
            width = maze[0].Length;
            field = maze;
        }

        /// <summary>
        /// Initialize the Maze for the player to walk in
        /// </summary>
        /// <returns> String with the Maze </returns>
        public static IList<String> Initialize ()
        {
            IList<String> mazeField = new List<String>();


            //mazeField.Add("#   #");
            //mazeField.Add("# # #");
            //mazeField.Add("#   #");

            mazeField.Add("#####################################");
            mazeField.Add("# #       #       #     #         # #");
            mazeField.Add("# # ##### # ### ##### ### ### ### # #");
            mazeField.Add("#       #   # #     #     # # #   # #");
            mazeField.Add("##### # ##### ##### ### # # # ##### #");
            mazeField.Add("#   # #       #     # # # # #     # #");
            mazeField.Add("# # ####### # # ##### ### # ##### # #");
            mazeField.Add("# #       # # #   #     #     #   # #");
            mazeField.Add("# ####### ### ### # ### ##### # ### #");
            mazeField.Add("#     #   # #   # #   #     # #     #");
            mazeField.Add("# ### ### # ### # ##### # # # #######");
            mazeField.Add("#   #   # # #   #   #   # # #   #   #");
            mazeField.Add("####### # # # ##### # ### # ### ### #");
            mazeField.Add("#     # #     #   # #   # #   #     #");
            mazeField.Add("# ### # ##### ### # ### ### ####### #");
            mazeField.Add("# #   #     #     #   # # #       # #");
            mazeField.Add("# # ##### # ### ##### # # ####### # #");
            mazeField.Add("# #     # # # # #     #       # #   #");
            mazeField.Add("# ##### # # # ### ##### ##### # #####");
            mazeField.Add("# #   # # #     #     # #   #       #");
            mazeField.Add("# # ### ### ### ##### ### # ##### # #");
            mazeField.Add("# #         #     #       #       # #");
            mazeField.Add("#X###################################");

            return mazeField;
        }
    }
}
