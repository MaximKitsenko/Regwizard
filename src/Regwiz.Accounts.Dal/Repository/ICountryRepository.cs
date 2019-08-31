using System.Collections.Generic;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> CreateCountrys(params Country[] messages);
        List<Country> ReadCountrys(params int[] ids);
        void UpdateCountrys(params Country[] messages);
        void DeleteCountrys(params Country[] messageIds);
        List<Country> ReadAllCountrys();
    }
}