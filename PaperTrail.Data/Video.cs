using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data
{
    public class Video : BranchAsset
    {
        [Required]
        public string Director {get;set;}
    }
}