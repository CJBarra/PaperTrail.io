using System;

namespace PaperTrail.Data.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual BranchAsset BranchAsset { get; set; }
        public virtual PatronCard PatronCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}