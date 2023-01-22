using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Data
{
    public class BankAPIDbContext : DbContext
    {
        //wykomentowac do migracji?
        public BankAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
