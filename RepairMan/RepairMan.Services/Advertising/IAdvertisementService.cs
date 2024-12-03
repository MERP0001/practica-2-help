using RepairMan.DataClasses.Advertising;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairMan.Services.Advertising
{
    public interface IAdvertisementService
    {
        IEnumerable<Advertisement> All(Expression<Func<Advertisement, bool>> predicate = null);
        Advertisement Create(Advertisement advertisement);
        Advertisement Delete(Advertisement advertisement);
        Advertisement Delete(Guid id);
        Advertisement Get(Guid id);
        Advertisement Update(Advertisement advertisement);
    }
}