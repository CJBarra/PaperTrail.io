using System.ComponentModel.DataAnnotations;

namespace PaperTrail.Data.Models
{
    public class BranchHours
    {
        public int Id { get; set; }
        public BranchOffice Branch { get; set; }
        [Range(0, 6)]
        public int DayOfWeek { get; set; }
        [Range(0, 23)]
        public int OpenHours { get; set; }
        [Range(0, 23)]
        public int ClosedHours { get; set; }

    }
}