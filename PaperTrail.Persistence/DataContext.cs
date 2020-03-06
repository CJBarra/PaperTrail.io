using Microsoft.EntityFrameworkCore;
using PaperTrail.Data;

namespace PaperTrail.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Value> Values { get; set; }
        // public virtual DbSet<Book> Books { get; set; }
        // public virtual DbSet<Video> Videos { get; set; }
        // public virtual DbSet<Checkout> Checkouts { get; set; }
        // public virtual DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        // public virtual DbSet<BranchOffice> BranchOffices { get; set; }
        // public virtual DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        // public virtual DbSet<PatronCard> PatronCards { get; set; }
        // public virtual DbSet<Status> Statuses { get; set; }
        // public virtual DbSet<LibraryAsset> LibraryAssets { get; set; }
        // public virtual DbSet<Hold> Holds { get; set; }
    }
}