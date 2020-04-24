using System;

namespace GUIForServer
{
    /// <summary>
    /// Class to write messages on console 
    /// </summary>
    public class WriteOnConsole : IWriteable
    {
        /// <summary>
        /// Writes a line on console
        /// </summary>
        public void Write(string line) => Console.WriteLine(line);

        /// <summary>
        /// Reads a line from console
        /// </summary>
        public string Read() => Console.ReadLine();
    }
}
