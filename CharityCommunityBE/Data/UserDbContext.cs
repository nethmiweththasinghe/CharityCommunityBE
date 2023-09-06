using CharityCommunityBE.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityCommunityBE.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { Database.Migrate(); }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<ProjectDetails> Projects { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<AdminDetails> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>().ToTable("users");
            modelBuilder.Entity<ProjectDetails>().ToTable("project");
            modelBuilder.Entity<ProjectDetails>().ToTable("volunteer");
            modelBuilder.Entity<AdminDetails>().ToTable("admin");
        }
    }
}