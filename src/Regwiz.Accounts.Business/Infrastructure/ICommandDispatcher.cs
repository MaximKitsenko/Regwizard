namespace Regwiz.Accounts.Business.Infrastructure
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}