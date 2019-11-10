using System;
using FTPServer;

namespace SimpleFTP.Tests
{
    public class WriteForTests : IWriteable
    {
        public void Write(string line) { }

        public string Read() => null;
    }
}
