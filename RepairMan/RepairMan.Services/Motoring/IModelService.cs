using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Motoring
{
    public interface IModelService
    {
        IEnumerable<Model> All(Expression<Func<Model, bool>> predicate = null);
        Model Create(Model vehicleModel);
        Model Delete(Guid id);
        Model Delete(Model vehicleModel);
        Model Get(Guid id);
        Model Update(Model vehicleModel);
    }
}