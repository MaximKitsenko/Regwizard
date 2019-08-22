using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class UserInfoRepository:IUserInfoRepository
    {
        private readonly RegwizContext _context;

        public UserInfoRepository(RegwizContext context)
        {
            _context = context;
        }

        public IEnumerable<UserInfo> CreateUserInfos(params UserInfo[] rooms)
        {
            var res = new List<EntityEntry<UserInfo>>();
            foreach (var room in rooms)
            {
                var temp = _context.UserInfos.Add(room);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<UserInfo> ReadUserInfos(params int[] ids)
        {
            var rooms = _context.UserInfos.AsNoTracking().Where(r => ids.Contains(r.Id));
            return rooms.ToList();
        }

        public void UpdateRooms(params UserInfo[] rooms)
        {
            var res = new List<EntityEntry<UserInfo>>();
            foreach (var room in rooms)
            {
                var temp = _context.UserInfos.Update(room);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }

        public void DeleteRooms(params UserInfo[] roomIds)
        {
            _context.UserInfos.RemoveRange(roomIds);
            _context.SaveChanges();
        }
    }
}