using System.Collections.Generic;

namespace BubbleSort.Tests
{
    /// <summary>
    /// Compares int numbers
    /// </summary>
    /// <typeparam name="T"> should be int </typeparam>
    public class IntComparator : IComparer<int>
    {
        /// <summary>
        /// Compares integer numbers
        /// </summary>
        /// <param name="first"> first number </param>
        /// <param name="second"> second number </param>
        /// <returns> difference between numbers </returns>
        public int Compare(int first, int second) => first - second;
    }
}
