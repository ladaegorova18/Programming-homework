using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new List.Menu();
            var list = new OneLinkedList();
            menu.WorkWithMenu(list);
        }
    }
}
