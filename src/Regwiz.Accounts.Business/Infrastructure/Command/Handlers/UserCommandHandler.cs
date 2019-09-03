using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Command.Handlers
{
    public class UserCommandHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserRepository _repository;

        public UserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateUser message)
        {
            var item = new User(0, message.Mail, message.Password,0);
            _repository.Create(item);
        }
    }
}