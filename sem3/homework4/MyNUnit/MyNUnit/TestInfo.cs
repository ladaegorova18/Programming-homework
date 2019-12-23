using System;

namespace MyNUnit
{
    public class TestInfo
    {
        public string Name { get; set; }

        public bool Crashed { get; set; }

        public bool Ignored { get; set; }

        public int Parameters { get; set; }

        public TestInfo()
        {

        }
    }
}
