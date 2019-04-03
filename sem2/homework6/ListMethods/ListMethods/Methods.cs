using System;
using System.Collections.Generic;
using System.Linq;

namespace ListMethods
{
    /// <summary>
    /// Three functions Map, Filter and Fold for work with list
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Map takes list and function and returns new list based on function
        /// </summary>
        /// <param name="list"> base list </param>
        /// <param name="func"> function to change list elements</param>
        /// <returns> new list </returns>
        public List<int> Map(List<int> list, Func<int, int> func)
        {
            List<int> newList = new List<int> { };
            foreach (var node in list)
            {
                newList.Add(node);
            }

            for (var i = 0; i < newList.Count(); ++i)
            {
                newList[i] = func(newList[i]);
            }

            return newList;
        }

        /// <summary>
        /// Filter takes list and bool function and returns new list of elements for which function is true
        /// </summary>
        /// <param name="list"> base list </param>
        /// <param name="func"> function to check list elements </param>
        /// <returns> new list </returns>
        public List<int> Filter(List<int> list, Func<int, bool> func)
        {
            List<int> newList = new List<int> { };
            foreach (var node in list)
            {
                if (func(node))
                {
                    newList.Add(node);
                }
            }
            return newList;
        }

        /// <summary>
        /// Fold takes list, int number and function to accumulate values of list
        /// </summary>
        /// <param name="list"> base list </param>
        /// <param name="acc"> first value to work </param>
        /// <param name="func"> function to change accumulate value </param>
        /// <returns> last accumulate value </returns>
        public int Fold(List<int> list, int acc, Func<int, int, int> func)
        {
            foreach (var node in list)
            {
                acc = func(acc, node);
            }
            return acc;  
        }
    }
}
