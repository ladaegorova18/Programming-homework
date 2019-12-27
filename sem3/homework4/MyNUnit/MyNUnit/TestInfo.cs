using System;
using System.Reflection;

namespace MyNUnit
{
    public class TestInfo
    {
        public string Name { get; set; }

        public bool Crashed { get; set; }

        public bool Ignored { get; set; }

        public string IgnoreReason { get; set; }

        public int Parameters { get; set; }

        public long Time { get; set; }

        public bool HasException { get; set; }

        public TestInfo(MethodInfo method)
        {
            Name = method.Name;
            Parameters = method.GetParameters().Length;
        }
    }
}
