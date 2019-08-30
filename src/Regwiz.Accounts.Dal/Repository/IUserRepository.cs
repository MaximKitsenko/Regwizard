using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> CreateUsers(params User[] messages);
        List<User> ReadUsers(params int[] ids);
        void UpdateUsers(params User[] messages);
        void DeleteUsers(params User[] messageIds);
    }
}