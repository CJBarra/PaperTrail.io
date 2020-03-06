using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data
{
    public class Patron
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Names limited to 30 characters.")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "Names limited to 30 characters.")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DoB { get; set; }
        public string PhoneNumber { get; set; }
        public virtual PatronCard PatronCard { get; set; }
        public virtual BranchOffice LocalBranchOffice { get; set; }
    }
}