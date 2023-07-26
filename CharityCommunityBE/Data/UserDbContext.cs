using CharityCommunityBE.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityCommunityBE.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserDetails> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>().ToTable("users");
        }
    }
}