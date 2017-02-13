using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    class Troll
    {
        public int coordX { get; set; }
        public int coordY { get; set; }

        public Troll(Player plyr)
        {
            // TODO: Don't let troll start where player or other troll is
            Random rnd = new Random();
            do
            {
                coordX = rnd.Next(1, Maze.width);
                coordY = rnd.Next(1, Maze.height);
            } while (Maze.field[coordY].ElementAt(coordX) != ' ');
        }

        public void Move(int targetX, int targetY)
        {
            if (targetX == coordX && targetY == coordY)
            {
                Draw.mazeExited = true;
            }
            findPath(targetX, targetY);
            
        }

        private void findPath(int targetX, int targetY)
        {
            var stepcount = 0;
            int tmpX = targetX, tmpY = targetY;
            List<Tuple<int, int, int>> path = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> tmpPath = new List<Tuple<int, int, int>>();

            // Initialize the end coordinate
            path.Add(new Tuple<int, int, int>(targetX, targetY, 0));
            // Go through every element in path
            for (int i = 1; i <= path.Count; i++)
            {
                tmpX = path[i - 1].Item1;
                tmpY = path[i - 1].Item2;

                // Create a list of the for adjacent cells
                tmpPath.Add(new Tuple<int, int, int>(tmpX + 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX - 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY + 1, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY - 1, i));

                for (int j = tmpPath.Count - 1; j > 0; j--)
                {
                    //If Cell is wall
                    if (Maze.field[tmpPath[j].Item2].ElementAt(tmpPath[j].Item1) == '#')
                    {
                        tmpPath.RemoveAt(j);
                        j--;
                    }

                    //TODO Try with Removeall
                    var x = path.FindAll(p => p.Item1.Equals(tmpPath[j].Item1)
                        & p.Item2.Equals(tmpPath[j].Item2) & p.Item3 <= tmpPath[j].Item3);

                    tmpPath = tmpPath.Except(x).ToList();
                }
                path.AddRange(tmpPath);
                tmpPath.Clear();

                if (path.Find(p => p.Item1.Equals(targetX)
                    & p.Item2.Equals(targetY)) != null)
                {
                    break;
                }
            }
            coordX = path[1].Item1;
            coordY = path[1].Item2;
        }
        
    }
}
