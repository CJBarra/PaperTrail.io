using System;
using System.Collections.Generic;

namespace PaperTrail.Data
{
    public class PatronCard
    {
        public int Id { get; set; }
        public double Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}