using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Advertising;
using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepairMan.Services.Motoring
{
    public class BrandService : IBrandService
    {
        private readonly RepairManContext _context;

        private IQueryable<Brand> _vehicleBrands
        {
            get
            {
                return _context.Brands.Include(x => x.Models);
            }
        }

        public BrandService(RepairManContext context)
        {
            _context = context;
        }

        public Brand Create(Brand vehicleBrand)
        {
            _context.Add(vehicleBrand);
            _context.SaveChanges();
            return vehicleBrand;
        }

        public Brand Update(Brand vehicleBrand)
        {
            _context.Attach(vehicleBrand);
            _context.Entry(vehicleBrand).State = EntityState.Modified;
            _context.SaveChanges();
            return vehicleBrand;
        }

        public Brand Delete(Brand vehicleBrand)
        {
            _context.Remove(vehicleBrand);
            _context.SaveChanges();
            return vehicleBrand;
        }

        public Brand Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Brand Get(Guid id)
        {
            return _vehicleBrands.FirstOrDefault(x => x.BrandId == id);
        }

        public IEnumerable<Brand> All(Expression<Func<Brand, bool>> predicate = null)
        {
            return predicate == null ? _vehicleBrands : _vehicleBrands.Where(predicate);
        }
    }
}
