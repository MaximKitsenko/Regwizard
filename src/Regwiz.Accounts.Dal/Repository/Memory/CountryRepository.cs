using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Dal.Repository.Memory
{
    public class CountryRepository:ICountryRepository, IDisposable
    {
        private readonly RegwizContext _context;

        public CountryRepository(RegwizContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> CreateCountries(params Country[] countries)
        {
            var res = new List<EntityEntry<Country>>();
            foreach (var country in countries)
            {
                var temp = _context.Countries.Add(country);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<Country> ReadCountries(params int[] ids)
        {
            var countries = _context.Countries.AsNoTracking().Where(r => ids.Contains(r.Id));
            return countries.ToList();
        }
        
        public List<Country> ReadAllCountries()
        {
            var countries = _context.Countries.AsNoTracking();
            return countries.ToList();
        }
        
        public void UpdateCountries(params Country[] countries)
        {
            var res = new List<EntityEntry<Country>>();
            foreach (var country in countries)
            {
                var temp = _context.Countries.Update(country);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }
        
        public void DeleteCountries(params Country[] ids)
        {
            _context.Countries.RemoveRange(ids);
            _context.SaveChanges();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            //ReleaseUnmanagedResources();
            //if (disposing)
            //{
            //    _context?.Dispose();
            //}
        }

        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

        ~CountryRepository()
        {
            //Dispose(false);
        }
    }
}
