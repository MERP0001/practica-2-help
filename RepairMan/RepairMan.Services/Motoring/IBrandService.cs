using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Motoring
{
    public interface IBrandService
    {
        IEnumerable<Brand> All(Expression<Func<Brand, bool>> predicate = null);
        Brand Create(Brand vehicleBrand);
        Brand Delete(Guid id);
        Brand Delete(Brand vehicleBrand);
        Brand Get(Guid id);
        Brand Update(Brand vehicleBrand);
    }
}