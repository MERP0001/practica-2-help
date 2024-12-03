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

namespace RepairMan.Services.Motoring
{
    public class VehicleService : IVehicleService
    {
        private readonly RepairManContext _context;

        private IQueryable<Vehicle> _vehicles
        {
            get
            {
                return _context.Vehicles.Include(x => x.Model).ThenInclude(x => x.Brand).AsNoTracking();
            }
        }

        public VehicleService(RepairManContext context)
        {
            _context = context;
        }

        public Vehicle Create(Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();
            return vehicle;
        }

        public Vehicle Update(Vehicle vehicle)
        {
            _context.Update(vehicle);
            _context.SaveChanges();
            return vehicle;
        }

        public Vehicle Delete(Vehicle vehicle)
        {
            _context.Remove(vehicle);
            _context.SaveChanges();
            return vehicle;
        }

        public Vehicle Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Vehicle Get(Guid id)
        {
            return _vehicles.FirstOrDefault(x => x.VehicleId == id);
        }

        public IEnumerable<Vehicle> All(Expression<Func<Vehicle, bool>> predicate = null)
        {
            return predicate == null ? _vehicles : _vehicles.Where(predicate);
        }
    }
}
