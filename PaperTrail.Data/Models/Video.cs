using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public class Video : BranchAsset
    {
        [Required]
        public string Director {get;set;}
    }
}