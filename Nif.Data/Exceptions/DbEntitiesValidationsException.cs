using System;

namespace Nif.Data.Exceptions
{
    public class DbEntitiesValidationsException : Exception
    {
        public DbEntitiesValidationsException() { }

        public DbEntitiesValidationsException(string message) : base(message) { }
    }
}