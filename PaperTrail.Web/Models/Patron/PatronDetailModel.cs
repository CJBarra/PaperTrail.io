using System;
using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Web.Models.Patron
{
    public class PatronDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;
        public string FullNameGet
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int PatronCardId { get; set; }
        public string Address { get; set; }
        public DateTime MemberSince { get; set; }
        public string Phone { get; set; }
        public string LocalBranchOffice { get; set; }
        public double OverdueFees { get; set; }
        public IEnumerable<Checkout> ItemCheckedOut { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}