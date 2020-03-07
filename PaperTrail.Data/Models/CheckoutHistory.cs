using System;
using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }
        [Required]
        public BranchAsset BranchAsset { get; set; }
        [Required]
        public PatronCard PatronCard { get; set; }
        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}