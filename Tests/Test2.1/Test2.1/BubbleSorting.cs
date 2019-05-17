using System.Collections.Generic;

namespace Test2
{
    /// <summary>
    /// Bubble sort for generic types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSorting<T>
    {
        public List<T> Sort(List<T> list, IComparer<T> comparer)
        {
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
