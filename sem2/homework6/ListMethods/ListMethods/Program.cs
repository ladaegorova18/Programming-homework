using System;
using System.Collections.Generic;

namespace ListMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 4, 1, 1, 7 };
            var methods = new Methods();
            var mapList = methods.Map(list, x => x * 3);
            var filterList = methods.Filter(list, x => (x % 2 == 0));
            var foldList = methods.Fold(list, 1, (acc, node) => acc * node);
            var result = methods.Fold(new List<int> { 1, 2, 3 }, 1, (acc, elem) => acc * elem);
        }
    }
}