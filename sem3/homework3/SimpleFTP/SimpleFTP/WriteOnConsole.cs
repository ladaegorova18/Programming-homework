using System;

namespace FTPServer
{
    public class WriteOnConsole : IWriteable
    {
        public void Write(string line) => Console.WriteLine(line);

        public string Read() => Console.ReadLine();
    }
}
