using System;
using System.Runtime.Serialization;

namespace MoleAssist
{
    [Serializable]
    public class InputInvailedException : Exception
    {
        public InputInvailedException() : base()
        {
        }
        public InputInvailedException(string message) : base(message)
        {
        }
        public InputInvailedException(string message, Exception inner) : base(message, inner)
        {
        }
        protected InputInvailedException(SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
}
