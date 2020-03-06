using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data
{
    public class BranchOffice
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public string ImageUrl{get;set;}
        
        // ----------- Collections -----------
        public virtual IEnumerable<Patron> Patrons {get;set;}
        public virtual IEnumerable<BranchAsset> BranchAssets {get;set;}
    }
}