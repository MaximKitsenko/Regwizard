using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IProvinceRepository
    {
        IEnumerable<EntityEntry<Province>> CreateProvinces(params Province[] messages);
        List<Province> ReadProvinces(int userId);
        void UpdateProvinces(params Province[] messages);
        void DeleteProvinces(params Province[] messageIds);
    }
}