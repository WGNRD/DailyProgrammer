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
        public bool alive { get; set; }

        public Troll(Player plyr, Random rnd)
        {
            alive = true;

            do
            {
                coordX = rnd.Next(0, Maze.width);
                coordY = rnd.Next(0, Maze.height);
                
                //coordX = 1;
                //coordY = 0;
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
                tmpX = path[i - 1].Item1;
                tmpY = path[i - 1].Item2;

                // Create a list of the for adjacent cells
                tmpPath.Add(new Tuple<int, int, int>(tmpX + 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX - 1, tmpY, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY + 1, i));
                tmpPath.Add(new Tuple<int, int, int>(tmpX, tmpY - 1, i));
                
                foreach (var step in tmpPath)
                {

                     //If there is a element in list with the same coordinates but with a smaller counter
                    var tmpPath_in_path = from temp in tmpPath
                                          join pfad in path
                                          on temp.Item1 equals pfad.Item1
                                          where temp.Item2 == pfad.Item2 & temp.Item3 > pfad.Item3
                                          select temp;

                    tmpPath = tmpPath.Except(tmpPath_in_path).ToList();

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

            var adja = adjacent(coordX, coordY);
            

            tmpPath = (from pfad in path
                    join neig in adja
                    on pfad.Item1 equals neig.Item1
                    where neig.Item2 == pfad.Item2
                    select pfad).ToList();

            try
            {
                tmpPath.OrderBy(p => p.Item3).First();
            }catch(Exception)
            {
                tmpPath.Add(new Tuple<int, int, int>(coordX, coordY, 0));
            }

            coordX = tmpPath[0].Item1;
            coordY = tmpPath[0].Item2;

            path.Clear();
        }

        private List<Tuple<int,int>> adjacent(int xcoord, int ycoord)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            result.Add(new Tuple<int, int> (xcoord + 1, ycoord));
            result.Add(new Tuple<int, int> (xcoord, ycoord + 1));
            result.Add(new Tuple<int, int> (xcoord, ycoord - 1));
            result.Add(new Tuple<int, int> (xcoord - 1, ycoord));

            return result;
        }
        
        public bool isKilled()
        {
            var killed = false;

            if (Maze.field[coordX].ElementAt(coordY) == '#')
            {
                killed = true;
            }

            return killed;
        }
    }
}
