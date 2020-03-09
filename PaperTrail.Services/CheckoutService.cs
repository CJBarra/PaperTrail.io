using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaperTrail.Data.Interfaces;
using PaperTrail.Data.Models;
using PaperTrail.Persistence;

namespace PaperTrail.Services
{
    public class CheckoutService : ICheckout
    {
        private DataContext _context;
        // ------------ CONSTRUCTOR
        public CheckoutService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts;
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(p => p.PatronCard)
                .Include(x => x.BranchAsset)
                .Where(x => x.BranchAsset.Id == id);
        }

        public IEnumerable<Hold> GetCurrentReservations(int id)
        {
            return _context.Holds
                .Include(x => x.BranchAsset)
                .Where(x => x.BranchAsset.Id == id);
        }

        public string GetCurrentCheckoutPatron(int id)
        {
            var checkout = GetCheckoutByItemId(id);

            if (checkout == null)
            {
                return "";
            };

            var cardId = checkout.PatronCard.Id;
            var patron = _context.Patrons
                .Include(p => p.PatronCard)
                .FirstOrDefault(p => p.PatronCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
        }

        private Checkout GetCheckoutByItemId(int id)
        {
            return _context.Checkouts
                .Include(x => x.BranchAsset)
                .Include(x => x.PatronCard)
                .FirstOrDefault(x => x.BranchAsset.Id == id);
        }

        public string GetCurrentReservationPatronName(int resId)
        {
            var hold = _context.Holds
                .Include(x => x.BranchAsset)
                .Include(x => x.PatronCard)
                .FirstOrDefault(x => x.Id == resId);

            var cardId = hold?.PatronCard.Id;

            var patron = _context.Patrons
                .Include(p => p.PatronCard)
                .FirstOrDefault(p => p.PatronCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
        }

        public DateTime GetCurrentReservationPlaced(int resId)
        {
            return _context.Holds
                .Include(x => x.BranchAsset)
                .Include(x => x.PatronCard)
                .FirstOrDefault(x => x.Id == resId)
                .HoldPlaced;
        }


        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(x => x.Id == checkoutId);
        }

        public Checkout GetLatestCheckout(int checkoutId)
        {
            return _context.Checkouts
                .Where(x => x.BranchAsset.Id == checkoutId)
                .OrderByDescending(x => x.Since)
                .FirstOrDefault();
        }
        public void AddCheckout(Checkout addCheckout)
        {
            _context.Add(addCheckout);
            _context.SaveChanges();
        }

        public void CheckoutItem(int itemId, int patronCardId)
        {
            if (IsCheckedOut(itemId))
            {
                return;
            }

            var item = _context.BranchAssets
                .FirstOrDefault(x => x.Id == itemId);

            var patronCard = _context.PatronCards
                .Include(c => c.Checkouts)
                .FirstOrDefault(c => c.Id == patronCardId);

            var now = DateTime.Now;

            UpdateItemStatus(itemId, "Checked Out");
            AddNewCheckoutToList(item, patronCard, now);
            AddNewCheckoutHistoryToList(item, patronCard, now);

            _context.SaveChanges();
        }

        private void AddNewCheckoutToList(BranchAsset item, PatronCard patronCard, DateTime now)
        {
            var checkout = new Checkout
            {
                BranchAsset = item,
                PatronCard = patronCard,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };

            _context.Add(checkout);
        }

        private void AddNewCheckoutHistoryToList(BranchAsset item, PatronCard patronCard, DateTime now)
        {
            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                BranchAsset = item,
                PatronCard = patronCard
            };

            _context.Add(checkoutHistory);
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            /* TODO: Add logic for days allowed to checkout item by context, 
                    Books(14) , Videos(7), etc. */
            return now.AddDays(30);
        }

        public bool IsCheckedOut(int itemId)
        {
            return _context.Checkouts
                .Where(x => x.BranchAsset.Id == itemId)
                .Any();
        }

        public void MarkAvailable(int itemId)
        {
            var now = DateTime.Now;

            UpdateItemStatus(itemId, "Available");
            RemoveExistingCheckouts(itemId);
            CloseExistingCheckoutHistory(itemId, now);

            _context.SaveChanges();
        }

        public void MarkUnavailable(int itemId)
        {
            UpdateItemStatus(itemId, "N/A");
            _context.SaveChanges();
        }

        private void UpdateItemStatus(int itemId, string s)
        {
            var item = _context.BranchAssets
                .FirstOrDefault(x => x.Id == itemId);

            _context.Update(item);

            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == s);
        }

        private void CloseExistingCheckoutHistory(int itemId, DateTime now)
        {
            // Close existing checkout history
            var history = _context.CheckoutHistories
                .FirstOrDefault(x => x.BranchAsset.Id == itemId
                    && x.CheckedIn == null);

            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckouts(int itemId)
        {
            // If success, remove existing Checkouts collection
            var checkout = _context.Checkouts
                .FirstOrDefault(x => x.BranchAsset.Id == itemId);

            if (checkout != null)
                _context.Remove(checkout);
        }

        public void PlaceReservation(int itemId, int patronCardId)
        {
            var now = DateTime.Now;
            var item = _context.BranchAssets
                .Include(x=>x.Status)
                .FirstOrDefault(x => x.Id == itemId);
            var card = _context.PatronCards
                .FirstOrDefault(x => x.Id == patronCardId);

            if (item.Status.Name == "Available")
            {
                UpdateItemStatus(itemId, "Reserved");
            }

            var reservation = new Hold
            {
                HoldPlaced = now,
                BranchAsset = item,
                PatronCard = card
            };

            _context.Add(reservation);
            _context.SaveChanges();
        }

        public void ReturnItem(int itemId)
        {
            var now = DateTime.Now;
            var item = _context.BranchAssets
                .FirstOrDefault(x => x.Id == itemId);

            _context.Update(item);

            /* TODO: Remove and Close existing checkouts / history on item.
            Scan for item CurrentReservations and attach to next available index
            in Reservation collection, update item status to "Available" if next index
            is null. */

            RemoveExistingCheckouts(itemId);
            CloseExistingCheckoutHistory(itemId, now);
            SetCurrentReservationStatus(itemId);

            _context.SaveChanges();
        }

        private void SetCurrentReservationStatus(int itemId)
        {
            var currentReservations = _context.Holds
                .Include(r => r.BranchAsset)
                .Include(r => r.PatronCard)
                .Where(r => r.BranchAsset.Id == itemId);

            if (currentReservations.Any())
            {
                CheckoutToEarliestReservationIndex(itemId, currentReservations);
            }
            else
            {
                UpdateItemStatus(itemId, "Available");
            }
        }

        private void CheckoutToEarliestReservationIndex(int itemId, IQueryable<Hold> currentReservations)
        {
            var earliestReservationIndex = currentReservations
                .OrderBy(e => e.HoldPlaced)
                .FirstOrDefault();

            var card = earliestReservationIndex.PatronCard;

            _context.Remove(earliestReservationIndex);
            _context.SaveChanges();
            CheckoutItem(itemId, card.Id);
        }
    }
}