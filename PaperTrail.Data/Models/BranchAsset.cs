using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public abstract class BranchAsset
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public Status Status { get; set; }

        [Required]
        [Display(Name = "Cost of Replacement")]
        public double Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }
        public virtual BranchOffice Location { get; set; }
    }
}