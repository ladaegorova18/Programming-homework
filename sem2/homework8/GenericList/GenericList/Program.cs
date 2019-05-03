using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Переделать список на генерики. Список должен реализовывать интерфейс 
 * System.Collections.Generic.IList, в том числе иметь энумератор, чтобы можно было 
 * по нему ходить foreach.*/

namespace GenericList
{
    /// <summary>
    /// main class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        public static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(3);
            list.Add(8);
            list.Add(7);
            foreach (var node in list)
            {
                Console.Write(node + " ");
            }
        }
    }
}
