using System;

namespace Lists
{
    /// <summary>
    /// Exception that throws an exception when removing nonexistent element
    /// </summary>
    [Serializable]
    public class RemovingNonexistentNodeException : Exception
    {
        public RemovingNonexistentNodeException() { }
        public RemovingNonexistentNodeException(string message) : base(message) { }
        public RemovingNonexistentNodeException(string message, Exception inner)
            : base(message, inner) { }
        protected RemovingNonexistentNodeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
