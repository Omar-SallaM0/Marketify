using Marketify.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketify.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Title="Action",DisplayOrder=1},
                new Category { Id=2,Title="SCI",DisplayOrder=2},
                new Category { Id=3,Title="History",DisplayOrder=3 }
                );

        }
    }
}
