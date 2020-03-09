using System;
using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Data.Interfaces
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        IEnumerable<Hold> GetCurrentReservations(int id); // current holds
        
        Checkout GetById(int checkoutId);
        Checkout GetLatestCheckout(int checkoutId);
        string GetCurrentCheckoutPatron(int id);
        string GetCurrentReservationPatronName(int id);
        DateTime GetCurrentReservationPlaced(int id);
        
        void AddCheckout(Checkout addCheckout); //add
        void CheckoutItem(int itemId, int patronCardId); // checkout 
        void ReturnItem(int itemId); // check in
        void PlaceReservation(int itemId, int patronCardId); //place hold
        void MarkUnavailable(int itemId); // lost
        void MarkAvailable(int itemId); //found
        bool IsCheckedOut(int id);
    }
}