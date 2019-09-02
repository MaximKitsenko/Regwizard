using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Business.Infrastructure.Query
{
    public class UserQueryHandler : IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly IUserRepository _repository;

        public UserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public User[] Execute(FindUsersBySearchTextQuery query)
        {
            var users = _repository.ReadAll();
            return users.Where(user => user.Mail.Contains(query.SearchText)).ToArray();
        }
    }
}