using System;

namespace SimpleFTP
{
    /// <summary>
    /// WriteOnConsole to write on console at runtime
    /// </summary>
    public class WriteOnConsole : IWriteable
    {
        /// <summary>
        /// write a message on console
        /// </summary>
        public void Write(string line) => Console.WriteLine(line);

        /// <summary>
        /// read a message from console
        /// </summary>
        public string Read() => Console.ReadLine();
    }
}
