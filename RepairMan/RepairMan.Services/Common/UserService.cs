using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepairMan.Services.Common
{
    public class UserService : IUserService
    {
        private readonly RepairManContext _context;

        private IQueryable<User> _users
        {
            get
            {
                return _context.Users.Include(x => x.Contact).Include(x => x.Vehicles).ThenInclude(x => x.Model).ThenInclude(x => x.Brand).AsNoTracking();
            }
        }

        public UserService(RepairManContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> All(Expression<Func<User, bool>> predicate = null)
        {
            return predicate == null ? _users : _users.Where(predicate);
        }
    }
}
