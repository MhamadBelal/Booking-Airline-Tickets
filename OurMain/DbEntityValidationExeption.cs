using System;
using System.Runtime.Serialization;

namespace OurMain
{
    [Serializable]
    internal class DbEntityValidationExeption : Exception
    {
        public DbEntityValidationExeption()
        {
        }

        public DbEntityValidationExeption(string message) : base(message)
        {
        }

        public DbEntityValidationExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbEntityValidationExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}