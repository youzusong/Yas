using System.Runtime.Serialization;

namespace System
{
    public class YasException : Exception
    {
        public YasException()
        { }

        public YasException(string message)
            : base(message)
        { }

        public YasException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public YasException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
