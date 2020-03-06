using Microsoft.EntityFrameworkCore;
using PaperTrail.Data;

namespace PaperTrail.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Value> Values { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<PatronCard> PatronCards { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<BranchAsset> BranchAssets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Hold> Holds { get; set; }


        // Override onModelCreating method to configure Entities during migration creation.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Value>().HasData(
                new Value { Id = 1, Name = "Value 101" },
                new Value { Id = 2, Name = "Value 102" },
                new Value { Id = 3, Name = "Value 103" }
                );
        }
    }
}