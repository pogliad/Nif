using System;
using System.Diagnostics.Contracts;
using Nif.Core.Extensions;

namespace Nif.Data.Specification
{
    public abstract class CompositeSpecificationBase<TEntity> : SpecificationBase<TEntity>
    {
        private readonly ISpecification<TEntity> _leftSpecification;
        private readonly ISpecification<TEntity> _rightSpecification;

        protected CompositeSpecificationBase(ISpecification<TEntity> leftSpecification, ISpecification<TEntity> rightSpecification)
        {
            Contract.Requires<ArgumentNullException>(leftSpecification.IsNotNull());
            Contract.Requires<ArgumentNullException>(rightSpecification.IsNotNull());

            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public ISpecification<TEntity> LeftSpecification { get { return _leftSpecification; } }
        public ISpecification<TEntity> RightSpecification { get { return _rightSpecification; } }
    }
}