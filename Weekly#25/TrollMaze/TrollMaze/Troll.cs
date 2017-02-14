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
            for (int i = 0; i < path.Count; i++)
            {
                tmpX = path[i].Item1;
                tmpY = path[i].Item2;

                // Create a list of the for adjacent cells
                tmpPath.Add(new Tuple<int, int, int>(tmpX + 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX - 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY + 1, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY - 1, i));

                foreach (var step in tmpPath)
                {
                    //If there is a element in list with the same coordinates but with a smaller counter

                    if (tmpPath.Count > 0)
                    {
                        var x = path.FindAll(p => p.Item1.Equals(step.Item1)
                            & p.Item2.Equals(step.Item2)
                            & p.Item3 <= step.Item3);
                    }

                    //var test = x.FindAll(t => t.Item1 == x.Select(d => d.Item1).First());

                    var y = tmpPath.FindAll(
                            t => t.Item1.Equals(path.Select(p => p.Item1).First())
                            && t.Item2.Equals(path.Select(p => p.Item2).First() ));

                    tmpPath = tmpPath.Except(y).ToList();
                    
                    //If Cell is wall
                    try
                    {
                        if (Maze.field[step.Item2].ElementAt(step.Item1) == '#')
                        {
                            tmpPath.Remove(step);
                        }
                    }
                    catch (Exception)
                    {
                        tmpPath.Remove(step);
                    }
                }

                // Add all remaining cells
                path.AddRange(tmpPath);
                tmpPath.Clear();


                if (path.Find(p => p.Item1.Equals(coordX) & p.Item2.Equals(coordY)) != null)
                {
                    break;
                }

            }


            // Go to the nearby cell with the lowest number
            path.Where(p => p.Item1 == coordX +1 || p.Item1 == coordX -1);
            

            //var min = path.min(p => p.Item3);

            foreach (int[] neighbour in adjacent(coordX,coordY))
            {
                int min=100000;
                var my = path.Where(p => p.Item1 == neighbour[0] & p.Item2 == neighbour[1]).Select(p=>p);

                if (min < my.Select(p=>p.Item3).First())
                {
                    coordX = my.Select(p => p.Item1).First();
                    coordY = my.Select(p => p.Item2).First();

                    min = my.Select(p => p.Item3).First();
                }
            }
            
            path.Clear();
        }

        private List<int[]> adjacent(int xcoord, int ycoord)
        {
            List<int[]> result = new List<int[]>();

            result.Add(new int[2] { xcoord + 1, ycoord});
            result.Add(new int[2] { xcoord, ycoord + 1});
            result.Add(new int[2] { xcoord, ycoord - 1});
            result.Add(new int[2] { xcoord - 1, ycoord});

            return result;
        }        
    }
}
