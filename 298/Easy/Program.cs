// Author: @Dominik_Wagner
// Date: 06.01.2017
// Solution to the Reddit Coding Challenge "#298 Too many Parenthesis"
// URL: https://www.reddit.com/r/dailyprogrammer/comments/5llkbj/2017012_challenge_298_easy_too_many_parentheses/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_298_Too_many_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Properties
            String input;
            List<int> duplicated = new List<int>();
            #endregion

            input = Console.ReadLine();
            //input = "(((zbcd)(((e)fg))))";

            // Removes all empty Parenthesis
            input = input.Replace("()", "");

            // Gets a list with the duplicated Parenthesis
            duplicated = FindDuplicated(FindMatchingParenthesis(input));

            // Orders the list desc. because of wrong indexes if front chars are removed first
            duplicated = duplicated.OrderByDescending(i => i).ToList(); 
            
            // Removes the Elements from the Input
            for (int i = 0; i < duplicated.Count; i++)
            {
                input = input.Remove(duplicated.ElementAt(i), 1);
            }

            Console.WriteLine(input);
            Console.ReadKey();
        }

        /// <summary>
        /// Finds pairs of parenthesis and adds their index them in a list together.
        /// The open parenthesis has an odd index. The closing one an even index.
        /// Finds it by tracking the "deepness" of the parenthesis with a stack.
        /// </summary>
        /// <param name="input">Made from user</param>
        /// <returns>List with all matching parenthesis</returns>
        public static List<int> FindMatchingParenthesis(string input)
        {
            char[] array = input.ToCharArray();
            Stack<int> stack = new Stack<int>();
            List<int> matches = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '(')
                {
                    stack.Push(i);
                }
                if (array[i] == ')')
                {
                    matches.Add(i);
                    //TODO: Take exception when there are not the same amount of opening and closing parenthis
                    matches.Add(stack.Pop());
                }
            }
            return matches;
        }

        /// <summary>
        /// Finds duplicated (redundant) parenthesis in a list of parenthesis.
        /// </summary>
        /// <param name="matches">List of index of parenthesis</param>
        /// <returns>List of index of redundant parenthesis</returns>
        public static List<int> FindDuplicated(List<int> matches)
        {
            #region Properties
            List<int> retList = new List<int>();
            int duplicated;
            int duplicatedIndex;
            #endregion

            // Check every opening parenthesis for neighbours
            for (int i = 0; i < matches.Count; i += 2)
            {
                duplicated = matches.ElementAt<int>(i) - 1;
                duplicatedIndex = matches.IndexOf(duplicated);

                // To find only the open parenthesis, check if index is even
                if ((duplicatedIndex % 2 == 0) & (true))
                {
                    // Check if closing parenthesis are neighbours
                    if (matches.ElementAt<int>(duplicatedIndex+1)-1 == matches.ElementAt<int>(i+1))
                    {
                        retList.Add(matches.ElementAt(i));
                        retList.Add(matches.ElementAt(i+1));
                    }
                }
                
            }
            return retList;
        }
    }
}
