using System;

namespace Nif.Data.Exceptions
{
    public class EntityLastModifyDateTimeIsLessThanCreateDateTimeException : Exception
    {
        public EntityLastModifyDateTimeIsLessThanCreateDateTimeException() { }

        public EntityLastModifyDateTimeIsLessThanCreateDateTimeException(string message) : base(message) { }
    }
}