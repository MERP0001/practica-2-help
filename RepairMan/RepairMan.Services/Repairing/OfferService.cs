using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Repairing;

namespace RepairMan.Services.Repairing
{
    public class OfferService : IOfferService
    {
        private readonly RepairManContext _context;

        private IQueryable<Offer> _offers
        {
            get
            {
                return _context.Offers.Include(x => x.Workshop).Include(x => x.Category).AsNoTracking();
            }
        }

        public OfferService(RepairManContext context)
        {
            _context = context;
        }

        public Offer Create(Offer offer)
        {
            offer.Category = null;
            offer.Workshop = null;
            _context.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        public Offer Update(Offer offer)
        {
            offer.Category = null;
            offer.Workshop = null;
            _context.Attach(offer);
            _context.Entry(offer).State = EntityState.Modified;
            _context.SaveChanges();
            return offer;
        }

        public Offer Delete(Offer offer)
        {
            _context.Remove(offer);
            _context.SaveChanges();
            return offer;
        }

        public Offer Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public Offer Get(Guid id)
        {
            return _offers.FirstOrDefault(x => x.OfferId == id);
        }

        public IEnumerable<Offer> All(Expression<Func<Offer, bool>> predicate = null)
        {
            return predicate == null ? _offers : _offers.Where(predicate);
        }
    }
}
