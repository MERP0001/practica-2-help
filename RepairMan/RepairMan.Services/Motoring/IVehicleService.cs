using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Motoring
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> All(Expression<Func<Vehicle, bool>> predicate = null);
        Vehicle Create(Vehicle vehicle);
        Vehicle Delete(Guid id);
        Vehicle Delete(Vehicle vehicle);
        Vehicle Get(Guid id);
        Vehicle Update(Vehicle vehicle);
    }
}