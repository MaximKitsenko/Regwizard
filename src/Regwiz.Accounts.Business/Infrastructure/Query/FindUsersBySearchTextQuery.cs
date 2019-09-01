using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Business.Infrastructure.Query
{
    public class FindUsersBySearchTextQuery : IQuery<User[]>
    {
        public string SearchText { get; }
        public bool InactiveUsers { get; }

        public FindUsersBySearchTextQuery(string searchText, bool inactiveUsers)
        {
            SearchText = searchText;
            InactiveUsers = inactiveUsers;
        }
    }
}