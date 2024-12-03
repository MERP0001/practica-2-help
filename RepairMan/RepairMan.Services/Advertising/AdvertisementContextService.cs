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
    public class AdvertisementContextService
    {
        private readonly RepairManContext _context;

        private IQueryable<AdvertisementContext> _advertisementContexts
        {
            get
            {
                return _context.AdvertisementContexts.Include(x => x.Advertisements).Include(x => x.Geoposition).Include(x => x.WorkshopCategory).AsNoTracking();
            }
        }

        public AdvertisementContextService(RepairManContext context)
        {
            _context = context;
        }

        public AdvertisementContext Create(AdvertisementContext advertisementContext)
        {
            _context.Add(advertisementContext);
            _context.SaveChanges();
            return advertisementContext;
        }

        public AdvertisementContext Update(AdvertisementContext advertisementContext)
        {
            _context.Attach(advertisementContext);
            _context.Entry(advertisementContext).State = EntityState.Modified;
            _context.SaveChanges();
            return advertisementContext;
        }

        public AdvertisementContext Delete(AdvertisementContext advertisementContext)
        {
            _context.Remove(advertisementContext);
            _context.SaveChanges();
            return advertisementContext;
        }

        public AdvertisementContext Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public AdvertisementContext Get(Guid id)
        {
            return _advertisementContexts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdvertisementContext> All(Expression<Func<AdvertisementContext, bool>> predicate = null)
        {
            return predicate == null ? _advertisementContexts : _advertisementContexts.Where(predicate);
        }
    }
}
