using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaperTrail.Data.Interfaces;
using PaperTrail.Data.Models;
using PaperTrail.Persistence;

namespace PaperTrail.Services
{
    public class PatronService : IPatron
    {
        private DataContext _context;

        public PatronService(DataContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(x => x.PatronCard)
                .Include(x => x.LocalBranchOffice);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            var cardId = Get(patronId).PatronCard.Id;

            return _context.CheckoutHistories
                .Include(co => co.PatronCard)
                .Include(co => co.BranchAsset)
                .Where(co => co.PatronCard.Id == cardId)
                .OrderByDescending(co => co.CheckedOut);
        }

        public IEnumerable<Checkout> GetPatronCheckouts(int patronId)
        {
            var cardId = Get(patronId).PatronCard.Id;

            return _context.Checkouts
                .Include(co => co.PatronCard)
                .Include(co => co.BranchAsset)
                .Where(co => co.PatronCard.Id == cardId);
        }
        
        public IEnumerable<Hold> GetHolds(int patronId)
        {
            var cardId = Get(patronId).PatronCard.Id;

            return _context.Holds
                .Include(h => h.PatronCard)
                .Include(h => h.BranchAsset)
                .Where(h => h.PatronCard.Id == cardId)
                .OrderByDescending(h => h.HoldPlaced);
        }

    }
}