using System;
using System.Collections.Generic;

namespace Test2
{
    /// <summary>
    /// compares two lists
    /// </summary>
    /// <typeparam name="T"> type of elements in list </typeparam>
    public class ListComparator<T> : IComparer<List<T>>
    {
        /// <summary>
        /// compares amount of elements in lists
        /// </summary>
        /// <param name="x"> first list </param>
        /// <param name="second"> second list </param>
        /// <returns></returns>
        public int Compare(List<T> first, List<T> second) => first.Count - second.Count;
    }
}
