using System.Collections.Generic;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Create(params T[] messages);
        List<T> Read(params int[] ids);
        void Update(params T[] messages);
        void Delete(params T[] messageIds);
        List<T> ReadAll();
    }
}