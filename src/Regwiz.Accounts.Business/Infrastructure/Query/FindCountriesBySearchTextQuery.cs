using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Business.Infrastructure.Query
{
    public class FindCountriesBySearchTextQuery : IQuery<Country[]>
    {
        public string SearchText { get; }
        public bool InactiveCountrys { get; }

        public FindCountriesBySearchTextQuery(string searchText, bool inactiveCountrys)
        {
            SearchText = searchText;
            InactiveCountrys = inactiveCountrys;
        }
    }
}