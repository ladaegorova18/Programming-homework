using System;

namespace SimpleFTP
{
    /// <summary>
    /// main server program
    /// </summary>
    public class Program
    {
        private static Server server;

        private static void Main(string[] args) 
        {
            Console.WriteLine("Enter port:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int port))
            {
                server = new Server(port, new WriteOnConsole());
                server.Process();
                Console.WriteLine("Server started work. To close server enter 'C'");
            }
            while (true)
            {
                var key = Console.ReadKey();
                if (key.KeyChar == 'C')
                {
                    server.Cancel();
                    return;
                }
            }
        }
    }
}
