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

        public Troll(Maze mz, Player plyr)
        {
            Random rnd = new Random();
            do
            {
                coordX = rnd.Next(1, mz.width);
                coordY = rnd.Next(1, mz.height);
            } while (mz.field[coordY].ElementAt(coordX) != ' '
            && plyr.locationX == coordX);
        }

        public void Move(Maze mz, int targetX, int targetY)
        {
            if (targetX == coordX && targetY == coordY)
            {
                Draw.mazeExited = true;
            }
            findPath(mz, targetX, targetY);
            
        }

        private void findPath(Maze mz, int targetX, int targetY)
        {
            List<Tuple<int, int, int>> path = new List<Tuple<int, int, int>>();

            path.Add(new Tuple<int, int, int>(targetX, targetY, 0));

            if(mz.field[targetY + 1].ElementAt(targetX) != '#')
            {

            }
            if (mz.field[targetY - 1].ElementAt(targetX) != '#')
            {

            }
            if (mz.field[targetY].ElementAt(targetX +1) != '#')
            {

            }
            if (mz.field[targetY - 1].ElementAt(targetX- 1) != '#')
            {

            }
        }
        
    }
}
