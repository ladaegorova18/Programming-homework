using System;

namespace SimpleFTP
{
    /// <summary>
    /// exception which throws when connection is failed
    /// </summary>
    [Serializable]
    public class ConnectionException : Exception
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public ConnectionException() { }

        /// <summary>
        /// constructor with exception message
        /// </summary>
        public ConnectionException(string message) : base(message) { }

        /// <summary>
        /// constructor with exception message and inner exception
        /// </summary>
        public ConnectionException(string message, Exception inner)
            : base(message, inner) { }

        protected ConnectionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
