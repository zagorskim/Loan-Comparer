using Loans_Comparer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Loans_Comparer.Data
{
    public class LoanComparerDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }

        public LoanComparerDbContext(DbContextOptions<LoanComparerDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var dataSeeder = new DataSeeder(this, builder);
            dataSeeder.SeedData();
        }
    }
    
}
