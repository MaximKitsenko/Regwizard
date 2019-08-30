using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface ICountryRepository:IDisposable
    {
        IEnumerable<Country> CreateCountrys(params Country[] messages);
        List<Country> ReadCountrys(params int[] ids);
        void UpdateCountrys(params Country[] messages);
        void DeleteCountrys(params Country[] messageIds);
        List<Country> ReadAllCountrys();
    }
}