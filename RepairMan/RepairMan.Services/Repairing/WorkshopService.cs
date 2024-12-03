using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Advertising;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepairMan.Services.Repairing
{
    public class WorkshopService : IWorkshopService
    {
        private readonly RepairManContext _context;

        private IQueryable<Workshop> _workshops
        {
            get
            {
                return _context.Workshops
                    .Include(x => x.Categorization)
                    .ThenInclude(x => x.WorkshopCategory)
                    .Include(x => x.BrandSpecializations)
                    .ThenInclude(x => x.Brand)
                    .Include(x => x.ModelSpecializations)
                    .ThenInclude(x => x.Model)
                    .Include(x => x.Contact)
                    .Include(x => x.Qualifications)
                    .Include(x => x.Geoposition)
                    .Include(x => x.Products)
                    .Include(x => x.Owner)
                    .ThenInclude(x => x.Contact)
                    .AsSplitQuery()
                    .AsNoTracking();
            }
        }

        public WorkshopService(RepairManContext context)
        {
            _context = context;
        }

        public Workshop Create(Workshop workshop)
        {
            _context.Add(workshop);
            _context.SaveChanges();
            return workshop;
        }

        public Workshop Update(Workshop workshop)
        {
            if(workshop.Categorization != null) { 
                _context.WorkshopCategorizations.Where(x => x.WorkshopId == workshop.WorkshopId).ToList().ForEach(x => _context.Remove(x));
            }
            _context.Update(workshop);
            _context.SaveChanges();
            return workshop;
        }

        public Workshop Delete(Workshop workshop)
        {
            _context.Remove(workshop);
            _context.SaveChanges();
            return workshop;
        }

        public Workshop Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Workshop Get(Guid id)
        {
            return _workshops.FirstOrDefault(x => x.WorkshopId == id);
        }

        public IEnumerable<Workshop> All(Expression<Func<Workshop, bool>> predicate = null)
        {
            
            return predicate == null ? _workshops : _workshops.ToList().AsQueryable().Where(predicate);
        }
    }
}
