using System;

namespace GUIForServer
{
    /// <summary>
    /// Class to write messages on console 
    /// </summary>
    public class WriteOnConsole : IWriteable
    {
        public void Write(string line) => Console.WriteLine(line);

        public string Read() => Console.ReadLine();
    }
}
