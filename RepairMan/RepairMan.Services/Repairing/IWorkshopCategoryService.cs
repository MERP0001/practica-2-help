using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Repairing
{
    public interface IWorkshopCategoryService
    {
        IEnumerable<WorkshopCategory> All(Expression<Func<WorkshopCategory, bool>> predicate = null);
        WorkshopCategory Create(WorkshopCategory workshopCategory);
        WorkshopCategory Delete(Guid id);
        WorkshopCategory Delete(WorkshopCategory workshopCategory);
        WorkshopCategory Get(Guid id);
        WorkshopCategory Update(WorkshopCategory workshopCategory);
    }
}