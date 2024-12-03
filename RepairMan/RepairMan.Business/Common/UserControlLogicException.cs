using System;
using System.Runtime.Serialization;

namespace RepairMan.Business.Common
{
    [Serializable]
    internal class UserControlLogicException : Exception
    {
        public UserControlLogicException()
        {
        }

        public UserControlLogicException(string message) : base(message)
        {
        }

        public UserControlLogicException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserControlLogicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}