using System.Collections.Generic;

namespace PaperTrail.Web.Models.Patron
{
    public class PatronIndexModel
    {
        public IEnumerable<PatronDetailModel> Patrons { get; set; }
    }
}