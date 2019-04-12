using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var queue = new Queue();
            queue.Enqueue(3, 0);
            queue.Enqueue(5, 1);
            queue.Enqueue(2, -5);
            queue.Enqueue(4, -34);
            queue.Enqueue(9, 22);
            Console.WriteLine("Элементы в очереди:");
            for (var i = 0; i < 5; ++i)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}
