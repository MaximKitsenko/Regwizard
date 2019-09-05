using System;
using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Command.Handlers
{
    public class UserCommandHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserRepository _repository;
        //private readonly object lockObj = new Object();

        public UserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateUser message)
        {
            //lock (lockObj)
            //{
                var thereIsSuchUser = _repository.ReadAll().Any(x => string.Equals(x.Mail, message.Mail, StringComparison.OrdinalIgnoreCase));
                if (thereIsSuchUser)
                {
                    throw new Exception("User with the same mail already exists");
                }

                var item = new User(0, message.Mail, message.Password, 0);
                _repository.Create(item);
            //}
        }
    }
}