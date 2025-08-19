using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
    {
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Ints)
                .HasConversion(
                    v => string.Join(",", v),                // to DB
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList()                         // from DB
                );
        }
    }
}
