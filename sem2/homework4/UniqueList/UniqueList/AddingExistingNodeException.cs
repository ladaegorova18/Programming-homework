using System;

namespace Lists
{
    [Serializable]
    public class AddingExistingNodeException : Exception
    {
        public AddingExistingNodeException() { }
        public AddingExistingNodeException(string message) : base(message) { }
        public AddingExistingNodeException(string message, Exception inner)
            : base(message, inner) { }
        protected AddingExistingNodeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
