using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class CountryRepository:ICountryRepository
    {
        private readonly RegwizContext _context;

        public CountryRepository(RegwizContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> CreateCountrys(params Country[] rooms)
        {
            var res = new List<EntityEntry<Country>>();
            foreach (var room in rooms)
            {
                var temp = _context.Countries.Add(room);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<Country> ReadCountrys(params int[] ids)
        {
            var rooms = _context.Countries.AsNoTracking().Where(r => ids.Contains(r.Id));
            return rooms.ToList();
        }

        public List<Country> ReadAllCountrys()
        {
            var rooms = _context.Countries.AsNoTracking();
            return rooms.ToList();
        }

        public void UpdateCountrys(params Country[] rooms)
        {
            var res = new List<EntityEntry<Country>>();
            foreach (var room in rooms)
            {
                var temp = _context.Countries.Update(room);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }

        public void DeleteCountrys(params Country[] roomIds)
        {
            _context.Countries.RemoveRange(roomIds);
            _context.SaveChanges();
        }
    }
}