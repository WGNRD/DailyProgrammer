using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMaze
{
    class Player
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
            int [] loc = Initialize();
            locationX = loc[0];
            locationY = loc[1];
            direction = 'v';
        }

        public static int [] Initialize()
        {
            Random rnd = new Random();
            int[] location = new int[2];
            int x,y;

            do
            {
                //x = rnd.Next(1, Maze.width);
                //y = rnd.Next(1, Maze.height);
                x = 3;
                y = 2;
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
            }else if (field != '#')
            {
                locationX = locX;
                locationY = locY;
            }else
            {
                Push(locX, locY);
            }
            
            
        }

        /// <summary>
        /// Pushes wall 
        /// </summary>
        /// <param name="locX">The X-coordinate the player would be</param>
        /// <param name="locY">The Y-coordinate the player would be</param>
        private void Push(int locX, int locY)
        {
            //TODO refactor Method
            char[] chars;
            char[] chars2;

            chars = Maze.field[locY].ToCharArray();
            
            switch (direction)
            {
                case '>':
                    if (chars[locX + 1] != '#')
                    {
                        chars[locX] = ' ';
                        chars[locX + 1] = '#';

                        Maze.field[locY] = new String(chars);
                        legalMove(locX, locY);
                    }
                    break;
                case '<':
                    if (chars[locX - 1] != '#')
                    {
                        chars[locX] = ' ';
                        chars[locX - 1] = '#';

                        Maze.field[locY] = new String(chars);
                        legalMove(locX, locY);
                    }
                    break;
                case 'v':
                    chars2 = Maze.field[locY+1].ToCharArray();
                    if (chars2[locX] != '#')
                    {
                        chars[locX] = ' ';
                        chars2[locX] = '#';

                        Maze.field[locY] = new string(chars);
                        Maze.field[locY + 1] = new String(chars2);

                        legalMove(locX, locY);
                    }
                    break;
                case '^':
                    chars2 = Maze.field[locY-1].ToCharArray();

                    if (chars2[locX] != '#')
                    {
                        chars[locX] = ' ';
                        chars2[locX] = '#';

                        Maze.field[locY] = new string(chars);
                        Maze.field[locY - 1] = new String(chars2);

                        legalMove(locX, locY);
                    }
                    break;
            }
        }
    }
}
