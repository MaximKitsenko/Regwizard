using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository.Memory;

namespace Regwiz.Accounts.Dal.Repository
{
    public interface IUserRepository: IRepository<User>
    {
    }
}
