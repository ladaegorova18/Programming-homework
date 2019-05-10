using System;
using System.Collections.Generic;

namespace Test2
{
    public class SortedSet<T>
    {
        private ListComparator<T> comparator;
        private List<List<T>> set = new List<List<T>>();

        /// <summary>
        /// amount of elements in set
        /// </summary>
        public int Count => set.Count;

        /// <summary>
        /// constructor of set
        /// </summary>
        /// <param name="comparator"> comparator to compare lists in set </param>
        public SortedSet(ListComparator<T> comparator) => this.comparator = comparator;

        /// <summary>
        /// adds list to set
        /// </summary>
        /// <param name="list"> list to set </param>
        public void Add(List<T> list)
        {
            for (var i = 0; i < list.Count; ++i)
            {
                if (comparator.Compare(list, set[i]) < 0)
                {
                    set.Insert(i, list);
                    return;
                }
            }
            set.Add(list);
        }

        /// <summary>
        /// prints set on console
        /// </summary>
        public void Print()
        {
            foreach (var list in set)
            {
                foreach (var word in list)
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
