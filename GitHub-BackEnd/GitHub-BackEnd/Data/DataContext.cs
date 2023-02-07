using GitHub_BackEnd.Data.Config;
using GitHub_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHub_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<string>>();
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<GitHubRepository> GitHubRepositories { get; set; }
        public DbSet<Owner> Owners { get; set; }


    }
}
