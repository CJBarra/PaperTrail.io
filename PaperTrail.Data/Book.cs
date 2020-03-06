using System;
using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data
{
    public class Book : BranchAsset
    {
        [Required]
        public Guid ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string DeweyIndex { get; set; }
    }
}