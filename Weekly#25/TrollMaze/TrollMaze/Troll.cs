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
                //coordX = rnd.Next(0, Maze.width);
                //coordY = rnd.Next(0, Maze.height);
                coordX = 1;
                coordY = 0;
            } while ((Maze.field[coordY].ElementAt(coordX) != ' ' )&& (coordX == plyr.locationX));
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

            int tmpX = targetX, tmpY = targetY;
            List<Tuple<int, int, int>> path = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> tmpPath = new List<Tuple<int, int, int>>();

            // Initialize the end coordinate
            path.Add(new Tuple<int, int, int>(targetX, targetY, 0));
            // Go through every element in path
            for (int i = 1; i <= path.Count; i++)
            {
                tmpX = path[path.Count - 1].Item1;
                tmpY = path[path.Count - 1].Item2;

                // Create a list of the for adjacent cells
                tmpPath.Add(new Tuple<int, int, int>(tmpX + 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX - 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY + 1, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY - 1, i));

                for (int j = tmpPath.Count - 1; j >= 0; j--)
                {

                    //If there is a element in list with the same coordinates but with a smaller counter
                    
                    //var x = tmpPath.FindAll(p => p.Item1.Equals()
                    //    & p.Item2.Equals(path[j].Item2) & p.Item3 <= path[j].Item3);

                    //tmpPath = tmpPath.Except(x).ToList();

                    //tmpPath.RemoveAll(p => p.Item1.Equals(tmpPath[j].Item1)
                    //    & p.Item2.Equals(tmpPath[j].Item2) & p.Item3 <= tmpPath[j].Item3);

                    //If Cell is wall
                    try { 
                    if (Maze.field[tmpPath[j].Item2].ElementAt(tmpPath[j].Item1) == '#')
                    {
                        tmpPath.RemoveAt(tmpPath.Count -1);
                    }
                    }
                    catch (Exception)
                    {
                        tmpPath.RemoveAt(tmpPath.Count - 1);
                    }

                }
                // Add all remaining cells
                path.AddRange(tmpPath);
                tmpPath.Clear();

                //if (path.Find(p => p.Item1.Equals(coordX)
                //    & p.Item2.Equals(coordY)) == null)
                //    break;
                if (path.Find(p => p.Item1.Equals(coordX) & p.Item2.Equals(coordY)) != null)
                {
                    break;
                }

            }

            coordX = path[path.Count -1].Item1;
            coordY = path[path.Count - 1].Item2;
        }
        
    }
}
