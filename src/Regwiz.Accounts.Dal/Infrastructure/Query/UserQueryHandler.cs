using System.Linq;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;

namespace Regwiz.Accounts.Dal.Infrastructure.Query
{
    public class UserQueryHandler : IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly IRepository<User> _repository;

        public UserQueryHandler(IRepository<User> repository)
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