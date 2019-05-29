using System.Collections.Generic;
using System;

namespace Test2
{
    /// <summary>
    /// Bubble sort for generic types
    /// </summary>
    /// <typeparam name="T"> generic type </typeparam>
    public class BubbleSorting<T>
    {
        /// <summary>
        /// sorts lists with comparator
        /// </summary>
        /// <returns> sorted list </returns>
        public List<T> Sort(List<T> list, IComparer<T> comparer)
        {
            if (list == null || comparer == null)
            {
                throw new ArgumentNullException();
            }
            for (var i = 0; i < list.Count; ++i)
            {
                for (var j = i + 1; j < list.Count; ++j)
                {
                    if (comparer.Compare(list[i], list[j]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}
