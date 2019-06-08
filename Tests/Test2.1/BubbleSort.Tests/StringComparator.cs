using System.Collections.Generic;
using System;

namespace BubbleSort.Tests
{
    /// <summary>
    /// Compares string by length
    /// </summary>
    public class StringComparator : IComparer<string>
    {
        /// <summary>
        /// Compare method
        /// </summary>
        /// <returns> difference between length of first and second string </returns>
        public int Compare(string first, string second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }
            return first.Length - second.Length;
        }
    }
}
