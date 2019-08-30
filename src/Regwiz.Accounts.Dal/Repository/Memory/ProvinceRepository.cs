using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class ProvinceRepository:IProvinceRepository
    {
        private readonly RegwizContext _context;

        public ProvinceRepository(RegwizContext context)
        {
            _context = context;
        }

        public IEnumerable<Province> CreateProvinces(params Province[] users)
        {
            var res = new List<EntityEntry<Province>>();
            foreach (var user in users)
            {
                var temp = _context.Provinces.Add(user);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<Province> ReadProvinces(params int[] ids)
        {
            var rooms = _context.Provinces.AsNoTracking().Where(r => ids.Contains(r.Id));
            return rooms.ToList();
        }

        public void UpdateProvinces(params Province[] rooms)
        {
            var res = new List<EntityEntry<Province>>();
            foreach (var room in rooms)
            {
                var temp = _context.Provinces.Update(room);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }

        public void DeleteProvinces(params Province[] roomIds)
        {
            _context.Provinces.RemoveRange(roomIds);
            _context.SaveChanges();
        }
    }
}