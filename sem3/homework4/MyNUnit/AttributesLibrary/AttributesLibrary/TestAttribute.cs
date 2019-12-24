using System;

namespace AttributesLibrary
{
    public class TestAttribute : Attribute
    {
        public Type Expected { get; set; } = null;

        public string Ignore { get; set; }
    }
}
