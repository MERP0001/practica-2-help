using RepairMan.DataClasses.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Common
{
    public interface IUserService
    {
        IEnumerable<User> All(Expression<Func<User, bool>> predicate = null);
        User Create(User user);
        User Delete(Guid id);
        User Delete(User user);
        User Get(Guid id);
        User Update(User user);
    }
}