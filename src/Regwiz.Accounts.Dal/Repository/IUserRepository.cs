
using System.Collections.Generic;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> CreateUsers(params User[] messages);
        List<User> ReadUsers(params int[] ids);
        void UpdateUsers(params User[] messages);
        void DeleteUsers(params User[] messageIds);
        List<User> ReadAllUsers();
    }
}
