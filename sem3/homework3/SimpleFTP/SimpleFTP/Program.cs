using System;
using System.IO;
using System.Threading.Tasks;

namespace SimpleFTP
{
    /// <summary>
    /// main server program
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter port or port and IP address:");
            var input = Console.ReadLine();
            var splitted = input.Split(new char[] { ' ' });
            if (Int32.TryParse(splitted[0], out int port))
            {
                if (splitted.Length == 2)
                {
                    Console.WriteLine("You have made a client");
                    var client = new Client();
                    client.Connect(8888, "localhost");
                    var listResponse = client.List("/test");
                    Console.WriteLine(listResponse.Result);
                }
                else
                {
                    Console.WriteLine("You have made a server");
                    var server = new Server(8888);
                    server.Process();
                }
            }
        }
    }
}
