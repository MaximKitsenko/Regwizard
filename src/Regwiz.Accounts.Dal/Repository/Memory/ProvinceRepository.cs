﻿using System.Collections.Generic;
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

        public IEnumerable<Province> CreateProvinces(params Province[] provinces)
        {
            var res = new List<EntityEntry<Province>>();
            foreach (var province in provinces)
            {
                var temp = _context.Provinces.Add(province);
                res.Add(temp);
            }

            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
            return res.Select(x => x.Entity).ToList();
        }

        public List<Province> ReadProvinces(params int[] ids)
        {
            var provinces = _context.Provinces.AsNoTracking().Where(r => ids.Contains(r.Id));
            return provinces.ToList();
        }
        
        public List<Province> ReadAllProvinces()
        {
            var provinces = _context.Provinces.AsNoTracking();
            return provinces.ToList();
        }
        
        public void UpdateProvinces(params Province[] provinces)
        {
            var res = new List<EntityEntry<Province>>();
            foreach (var province in provinces)
            {
                var temp = _context.Provinces.Update(province);
                res.Add(temp);
            }
            _context.SaveChanges();
            res.ForEach(x => x.State = EntityState.Detached);
        }
        
        public void DeleteProvinces(params Province[] ids)
        {
            _context.Provinces.RemoveRange(ids);
            _context.SaveChanges();
        }
    }
}
