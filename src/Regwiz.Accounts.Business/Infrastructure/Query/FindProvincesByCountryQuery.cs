using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Business.Infrastructure.Query
{
    public class FindProvincesByCountryQuery : IQuery<Province[]>
    {
        public bool InactiveProvinces { get; }
        public int Country { get; }

        public FindProvincesByCountryQuery(int countryId, bool inactiveProvinces)
        {
            Country = countryId;
            InactiveProvinces = inactiveProvinces;
        }
    }
}