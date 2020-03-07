using System;
using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Web.Models.Catalog
{
    public class CatalogIndexDetail
    {
        public int IndexId { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string DeweyCallNumber { get; set; }
        public string Status { get; set; }
        public double Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        public string PatronName { get; set; }
        public Checkout LatestCheckout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
    }


    public class CatalogIndexHold
    {
        public string PatronName { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}