using System;
using System.Runtime.Serialization;

namespace EmailUtil
{
    [Serializable]
    public class EmailNotProviderException : Exception
    {
        public EmailNotProviderException()
        {
        }

        public EmailNotProviderException(string message) : base(message)
        {
        }

        public EmailNotProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailNotProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}