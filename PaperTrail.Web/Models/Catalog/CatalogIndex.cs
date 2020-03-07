using System.Collections.Generic;

namespace PaperTrail.Web.Models.Catalog
{
    public class CatalogIndex
    {
        public IEnumerable<CatalogIndexListings> Indexes { get; set; }
    }
}