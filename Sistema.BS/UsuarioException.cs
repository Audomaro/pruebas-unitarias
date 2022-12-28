using System;
using System.Runtime.Serialization;

namespace Sistema.BS
{
    [Serializable]
    public class UsuarioException : Exception
    {
        public UsuarioException()
        {
        }

        public UsuarioException(string message) : base(message)
        {
        }

        public UsuarioException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsuarioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}