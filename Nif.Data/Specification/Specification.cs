using System;
using System.Linq.Expressions;

namespace Nif.Data.Specification
{
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        private Func<TEntity, bool> _compiledExpression;
        private Func<TEntity, bool> CompiledExpression { get { return _compiledExpression ?? (_compiledExpression = Predicate.Compile()); } }

        public abstract Expression<Func<TEntity, bool>> Predicate { get; }

        public bool IsSatisfiedBy(TEntity entity) { return CompiledExpression(entity); }
    }
}