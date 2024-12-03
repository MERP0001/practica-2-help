using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepairMan.Services.Repairing
{
    public class WorkshopCategoryService : IWorkshopCategoryService
    {
        private readonly RepairManContext _context;

        private IQueryable<WorkshopCategory> _workshopCategories
        {
            get
            {
                return _context.WorkshopCategories.AsNoTracking();
            }
        }

        public WorkshopCategoryService(RepairManContext context)
        {
            _context = context;
        }

        public WorkshopCategory Create(WorkshopCategory workshopCategory)
        {
            _context.Add(workshopCategory);
            _context.SaveChanges();
            return workshopCategory;
        }

        public WorkshopCategory Update(WorkshopCategory workshopCategory)
        {
            _context.Attach(workshopCategory);
            _context.Entry(workshopCategory).State = EntityState.Modified;
            _context.SaveChanges();
            return workshopCategory;
        }

        public WorkshopCategory Delete(WorkshopCategory workshopCategory)
        {
            _context.RemoveRange(_context.WorkshopCategorizations.Where(x => x.WorkshopCategoryId == workshopCategory.WorkshopCategoryId));
            _context.Remove(workshopCategory);
            _context.SaveChanges();
            return workshopCategory;
        }

        public WorkshopCategory Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public WorkshopCategory Get(Guid id)
        {
            return _workshopCategories.FirstOrDefault(x => x.WorkshopCategoryId == id);
        }

        public IEnumerable<WorkshopCategory> All(Expression<Func<WorkshopCategory, bool>> predicate = null)
        {
            return predicate == null ? _workshopCategories : _workshopCategories.Where(predicate);
        }
    }
}
