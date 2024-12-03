using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Advertising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepairMan.Services.Advertising
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly RepairManContext _context;

        private IQueryable<Advertisement> _advertisements
        {
            get
            {
                return _context.Advertisements.Include(x => x.Context).AsNoTracking().ToList().AsQueryable();
            }
        }

        public AdvertisementService(RepairManContext context)
        {
            _context = context;
        }

        public Advertisement Create(Advertisement advertisement)
        {
            _context.Add(advertisement);
            _context.SaveChanges();
            return advertisement;
        }

        public Advertisement Update(Advertisement advertisement)
        {
            _context.Attach(advertisement);
            _context.Entry(advertisement).State = EntityState.Modified;
            _context.SaveChanges();
            return advertisement;
        }

        public Advertisement Delete(Advertisement advertisement)
        {
            _context.Remove(advertisement);
            _context.SaveChanges();
            return advertisement;
        }

        public Advertisement Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Advertisement Get(Guid id)
        {
            return _advertisements.FirstOrDefault(x => x.AdvertisementId == id);
        }

        public IEnumerable<Advertisement> All(Expression<Func<Advertisement, bool>> predicate = null)
        {
            return predicate == null ? _advertisements : _advertisements.Where(predicate);
        }
    }
}
