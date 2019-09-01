
using System.Collections.Generic;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IProvinceRepository
    {
        IEnumerable<Province> CreateProvinces(params Province[] messages);
        List<Province> ReadProvinces(params int[] ids);
        void UpdateProvinces(params Province[] messages);
        void DeleteProvinces(params Province[] messageIds);
        List<Province> ReadAllProvinces();
    }
}
