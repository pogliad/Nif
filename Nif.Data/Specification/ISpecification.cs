using System;
using System.Linq.Expressions;

namespace Nif.Data.Specification
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}