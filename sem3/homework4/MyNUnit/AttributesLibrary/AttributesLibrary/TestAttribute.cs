using System;

namespace AttributesLibrary
{
    public class TestAttribute : Attribute
    {
        public Type Expected { get; set; } = null;

        public bool Ignored { get; set; }
    }
}
