using System;
using System.Linq;

namespace TrollMaze
{
    internal class Player
    {
        public char direction { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maze"></param>
        public Player()
        {
            int[] loc = Initialize();
            locationX = loc[0];
            locationY = loc[1];
            direction = 'v';
        }

        public static int[] Initialize()
        {
            Random rnd = new Random();
            int[] location = new int[2];
            int x, y;

            do
            {
                x = rnd.Next(1, Maze.width);
                y = rnd.Next(1, Maze.height);
            } while (Maze.field[y].ElementAt(x) != ' ');

            location[0] = x;
            location[1] = y;

            return location;
        }

        public void Move(ConsoleKey inputKey)
        {
            int tmpLocX = locationX;
            int tmpLocY = locationY;

            switch (inputKey)
            {
                case ConsoleKey.UpArrow:
                    direction = '^';
                    tmpLocY = locationY - 1;
                    legalMove(tmpLocX, tmpLocY);
                    break;

                case ConsoleKey.DownArrow:
                    direction = 'v';
                    tmpLocY = locationY + 1;
                    legalMove(tmpLocX, tmpLocY);
                    break;

                case ConsoleKey.RightArrow:
                    direction = '>';
                    tmpLocX = locationX + 1;
                    legalMove(tmpLocX, tmpLocY);
                    break;

                case ConsoleKey.LeftArrow:
                    direction = '<';
                    tmpLocX = locationX - 1;
                    legalMove(tmpLocX, tmpLocY);
                    break;
            }
        }

        /// <summary>
        /// Sets the player to the new location if the move is legal
        /// </summary>
        /// <param name="locX">The X-coordinate the player would be</param>
        /// <param name="locY">The Y-coordinate the player would be</param>
        private void legalMove(int locX, int locY)
        {
            char field = Maze.field[locY].ElementAt(locX);
            if (field == 'X')
            {
                Draw.mazeExited = true;
            }
            else if (field != '#')
            {
                locationX = locX;
                locationY = locY;
            }
            else
            {
                Push(locX, locY);
            }
        }

        /// <summary>
        /// Pushes wall - Calls CanPush
        /// </summary>
        /// <param name="locX">The X-coordinate the player would be</param>
        /// <param name="locY">The Y-coordinate the player would be</param>
        private void Push(int locX, int locY)
        {
            switch (direction)
            {
                case '>':
                    if (Maze.GetCell(locX + 1, locY) != '#')
                    {
                        Maze.SetCell(locX, locY, ' ');
                        Maze.SetCell(locX + 1, locY, '#');
                        legalMove(locX, locY);
                    }
                    break;

                case '<':
                    if (Maze.GetCell(locX - 1, locY) != '#')
                    {
                        Maze.SetCell(locX, locY, ' ');
                        Maze.SetCell(locX - 1, locY, '#');
                        legalMove(locX, locY);
                    }
                    break;

                case 'v':
                    if (Maze.GetCell(locX, locY + 1) != '#')
                    {
                        Maze.SetCell(locX, locY, ' ');
                        Maze.SetCell(locX, locY + 1, '#');
                        legalMove(locX, locY);
                    }
                    break;

                case '^':

                    if (Maze.GetCell(locX, locY - 1) != '#')
                    {
                        Maze.SetCell(locX, locY, ' ');
                        Maze.SetCell(locX, locY - 1, '#');
                        legalMove(locX, locY);
                    }
                    break;
            }
        }
    }
}