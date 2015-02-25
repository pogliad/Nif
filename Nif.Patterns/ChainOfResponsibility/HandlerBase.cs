using System;
using System.Diagnostics.Contracts;
using Nif.Core.Extensions;

namespace Nif.Patterns.ChainOfResponsibility
{
   public abstract class HandlerBase<T>
    {
        protected HandlerBase<T> _successor;

        public abstract void HandleRequest(T request);

        public void SetSuccessor(HandlerBase<T> successor)
        {
            Contract.Requires<ArgumentNullException>(successor.IsNotNull());

            _successor = successor;
        }
    }
}