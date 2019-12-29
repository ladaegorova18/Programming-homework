using System;

namespace MyNUnit.AttributesLibrary
{
    /// <summary>
    /// test methods attribute
    /// </summary>
    public class TestAttribute : Attribute
    {
        /// <summary>
        /// type of expectes exception if it is
        /// </summary>
        public Type Expected { get; set; } = null;

        /// <summary>
        /// method reason to ignore if it is ignored
        /// </summary>
        public string Ignore { get; set; }
    }
}
