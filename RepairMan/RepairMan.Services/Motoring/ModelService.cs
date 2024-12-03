using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Advertising;
using RepairMan.DataClasses.Motoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepairMan.Services.Motoring
{
    public class ModelService : IModelService
    {
        private readonly RepairManContext _context;

        private IQueryable<Model> _vehicleModels
        {
            get
            {
                return _context.Models;
            }
        }

        public ModelService(RepairManContext context)
        {
            _context = context;
        }

        public Model Create(Model vehicleModel)
        {
            _context.Add(vehicleModel);
            _context.SaveChanges();
            return vehicleModel;
        }

        public Model Update(Model vehicleModel)
        {
            _context.Attach(vehicleModel);
            _context.Entry(vehicleModel).State = EntityState.Modified;
            _context.SaveChanges();
            return vehicleModel;
        }

        public Model Delete(Model vehicleModel)
        {
            _context.Remove(vehicleModel);
            _context.SaveChanges();
            return vehicleModel;
        }

        public Model Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Model Get(Guid id)
        {
            return _vehicleModels.FirstOrDefault(x => x.ModelId == id);
        }

        public IEnumerable<Model> All(Expression<Func<Model, bool>> predicate = null)
        {
            return predicate == null ? _vehicleModels : _vehicleModels.Where(predicate);
        }
    }
}
