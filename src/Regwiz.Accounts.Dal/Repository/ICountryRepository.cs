
using System.Collections.Generic;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> CreateCountries(params Country[] messages);
        List<Country> ReadCountries(params int[] ids);
        void UpdateCountries(params Country[] messages);
        void DeleteCountries(params Country[] messageIds);
        List<Country> ReadAllCountries();
    }
}
