using System;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Business.Exceptions;

namespace Regwiz.Accounts.Business.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _resolver;

        public CommandDispatcher(IServiceProvider resolver)
        {
            _resolver = resolver;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var handler = (ICommandHandler<TCommand>)_resolver.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
                throw new CommandHandlerNotFoundException(typeof(TCommand).ToString());
            
            //consistency may be implemented via locking command execution
            handler.Execute(command);
        }
    }
}