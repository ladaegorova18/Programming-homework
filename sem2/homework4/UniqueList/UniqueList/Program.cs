namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var list = new List();
            menu.WorkWithMenu(list);
            var uniqueList = new UniqueList(list);
            menu.WorkWithMenu(uniqueList);
        }
    }
}
