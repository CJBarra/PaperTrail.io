using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public class Patron
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Names limited to 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Names limited to 30 characters.")]
        public string LastName { get; set; }
        
        [Required] 
        public string Address { get; set; }
        
        [Required]
        public string DoB { get; set; }
        public string PhoneNumber { get; set; }
        public virtual PatronCard PatronCard { get; set; }
        public virtual BranchOffice LocalBranchOffice { get; set; }
    }
}