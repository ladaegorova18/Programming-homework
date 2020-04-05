using System;

namespace MyNUnit
{
    /// <summary>
    /// Throws if a type has more than one method with BeforeAttribute/AfterAttribute
    /// </summary>
    [Serializable]
    public class MyTypeInitializationException : Exception
    {
        /// <summary>
        /// Empty exception constructor
        /// </summary>
        public MyTypeInitializationException() { }

        /// <summary>
        /// Exception constructor with message
        /// </summary>
        /// <param name="message"></param>
        public MyTypeInitializationException(string message) : base(message) { }

        /// <summary>
        /// Exception constructor with inner exception
        /// </summary>
        public MyTypeInitializationException(string message, Exception inner)
        : base(message, inner) { }

        protected MyTypeInitializationException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
