using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            var menu = new Menu();
            menu.WorkWithMenu(list);
            UniqueList uniqueList = (UniqueList) list;
            menu.WorkWithMenu(uniqueList);
        }
    }
}
