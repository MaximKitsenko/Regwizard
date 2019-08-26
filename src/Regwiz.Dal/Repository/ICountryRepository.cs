using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface ICountryRepository
    {
        IEnumerable<EntityEntry<Country>> CreateCountrys(params Country[] messages);
        List<Country> ReadCountrys(int userId);
        void UpdateCountrys(params Country[] messages);
        void DeleteCountrys(params Country[] messageIds);
    }
}