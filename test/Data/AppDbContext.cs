using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class AppDbContext :DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employes> Employes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Select Category" },
                new Category() { Id = 2, Name = "Electronics" },
                new Category() { Id = 3, Name = "Laptops" },
                new Category() { Id = 4, Name = "Mobiles" }

                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
