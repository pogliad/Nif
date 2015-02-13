using System;

namespace Nif.Data
{
    public abstract class EntityBase<T>
    {
        public T Id { get; protected set; }
        public DateTime? CreateDateTime { get; protected set; }
        public DateTime? LastModifyDateTime { get; set; }
    }
}