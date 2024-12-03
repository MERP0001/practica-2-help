using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RepairMan.DataClasses.Repairing;

namespace RepairMan.Services.Repairing
{
    public interface IOfferService
    {
        IEnumerable<Offer> All(Expression<Func<Offer, bool>> predicate = null);
        Offer Create(Offer offer);
        Offer Delete(Offer offer);
        Offer Delete(Guid id);
        Offer Get(Guid id);
        Offer Update(Offer offer);
    }
}