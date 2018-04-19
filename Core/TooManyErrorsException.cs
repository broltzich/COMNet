using System;
using System.Runtime.Serialization;

namespace Core
{
    [Serializable]
    internal class TooManyErrorsException : Exception
    {
        public TooManyErrorsException()
        {
        }

        public TooManyErrorsException(string message) : base(message)
        {
        }

        public TooManyErrorsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooManyErrorsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}