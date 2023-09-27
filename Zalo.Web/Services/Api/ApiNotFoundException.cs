using System.Runtime.Serialization;

namespace Zalo.Web.Services
{
    public class ApiNotFoundException : Exception
    {
        public ApiNotFoundException()
        {
        }

        public ApiNotFoundException(string message) : base(message)
        {
        }

        public ApiNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class ApiErrorException : Exception
    {
        private readonly string _correlationId;
        public string CorrelationId => _correlationId;

        public ApiErrorException()
        {
        }

        public ApiErrorException(string message) : base(message)
        {
        }

        public ApiErrorException(string message, string correlationId) : base(message)
        {
            _correlationId = correlationId;
        }

        public ApiErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiErrorException(string message, string correlationId, Exception innerException) : base(message, innerException)
        {
            _correlationId = correlationId;
        }

        protected ApiErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}