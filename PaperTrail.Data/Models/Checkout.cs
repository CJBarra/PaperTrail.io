using System;
using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public class Checkout
    {
        public int Id {get;set;}
        [Required]
        public BranchAsset BranchAsset {get;set;}
        public PatronCard PatronCard {get;set;}
        public DateTime Since {get;set;}
        public DateTime Until {get;set;}
    }
}