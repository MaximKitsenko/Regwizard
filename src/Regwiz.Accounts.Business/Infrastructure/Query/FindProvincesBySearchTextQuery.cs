using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Business.Infrastructure.Query
{
    public class FindProvincesBySearchTextQuery : IQuery<Province[]>
    {
        public string SearchText { get; }
        public bool InactiveProvinces { get; }

        public FindProvincesBySearchTextQuery(string searchText, bool inactiveProvinces)
        {
            SearchText = searchText;
            InactiveProvinces = inactiveProvinces;
        }
    }
}