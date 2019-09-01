namespace Regwiz.Accounts.Dal.Infrastructure
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}