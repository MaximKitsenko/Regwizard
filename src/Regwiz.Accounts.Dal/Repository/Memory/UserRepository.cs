using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class UserRepository:IUserRepository
    {
        private readonly RegwizContext _context;

        public UserRepository(RegwizContext context)
        {
            _context = context;
        }

        public IEnumerable<User> CreateUsers(params User[] users)
        {
            var res = new List<EntityEntry<User>>();
            foreach (var user in users)
            {
                var temp = _context.Users.Add(user);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<User> ReadUsers(params int[] ids)
        {
            var users = _context.Users.AsNoTracking().Where(r => ids.Contains(r.Id));
            return users.ToList();
        }
        
        public List<User> ReadAllUsers()
        {
            var users = _context.Users.AsNoTracking();
            return users.ToList();
        }
        
        public void UpdateUsers(params User[] users)
        {
            var res = new List<EntityEntry<User>>();
            foreach (var user in users)
            {
                var temp = _context.Users.Update(user);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }
        
        public void DeleteUsers(params User[] ids)
        {
            _context.Users.RemoveRange(ids);
            _context.SaveChanges();
        }
    }
}
