using System;
using System.Diagnostics.Contracts;
using Nif.Core.Extensions;

namespace Nif.Patterns.Command
{
    public class CommandInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            Contract.Requires<ArgumentException>(command.IsNotNull());

            _command = command;
        }

        public void Execute()
        {
            if (_command.IsNull())
            {
                throw new NullReferenceException("command");
            }

            _command.Execute();
        }        
    }
}