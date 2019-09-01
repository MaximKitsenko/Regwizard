using System;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Dal.Exceptions;

namespace Regwiz.Accounts.Dal.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ServiceProvider _resolver;

        public CommandDispatcher(ServiceProvider resolver)
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

            handler.Execute(command);
        }
    }
}