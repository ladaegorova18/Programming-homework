using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// Exception that throws when user tryes to delete head from empty queue
    /// </summary>
    [Serializable]
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException() { }
        public EmptyQueueException(string message) : base(message) { }
        public EmptyQueueException(string message, Exception inner)
            : base(message, inner) { }
        protected EmptyQueueException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
