using System;
using System.Linq.Expressions;

namespace Nif.Data.Specification
{
    public class AndSpecification<TEntity> : CompositeSpecificationBase<TEntity>
    {
        public AndSpecification(ISpecification<TEntity> leftSpecification, ISpecification<TEntity> rightSpecification) : base(leftSpecification, rightSpecification) { }

        public override Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                var arguments = Expression.Parameter(typeof(TEntity), "arguments");
                var predicate = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(LeftSpecification.Predicate, arguments),
                        Expression.Invoke(RightSpecification.Predicate, arguments)),
                    arguments);

                return predicate;
            }
        }
    }
}