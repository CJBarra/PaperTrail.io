using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Data.Interfaces
{
    public interface IPatron
    {
         Patron Get(int id);
         IEnumerable<Patron> GetAll();
         void Add(Patron newPatron);

         IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId);
         IEnumerable<Checkout> GetPatronCheckouts(int patronId);
         IEnumerable<Hold> GetHolds(int patronId);
    }
}