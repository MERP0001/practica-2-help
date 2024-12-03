using RepairMan.DataClasses.Repairing;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Repairing
{
    public interface IWorkshopService
    {
        IEnumerable<Workshop> All(Expression<Func<Workshop, bool>> predicate = null);
        Workshop Create(Workshop workshop);
        Workshop Delete(Guid id);
        Workshop Delete(Workshop workshop);
        Workshop Get(Guid id);
        Workshop Update(Workshop workshop);
    }
}