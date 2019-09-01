using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Dal.Infrastructure.Command
{
    public class UserCommandHandler : ICommandHandler<CreateUser>
    {
        private readonly IRepository<User> _repository;

        public UserCommandHandler(IRepository<User> repository)
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