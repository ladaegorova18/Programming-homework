using System;

namespace Lists
{
    /// <summary>
    /// Exception that throws when user tryes to add to list an already existing element
    /// </summary>
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
