using _1670_ApplicationDevelopment_Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace _1670_ApplicationDevelopment_Lab.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "ABC", DisplayOrder = 2, Description = "Tinh Cam" },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2, Description = "Hanh Dong" },
                new Category { Id = 3, Name = "Horrnor", DisplayOrder = 2, Description = "Kinh Di" },
                new Category { Id = 4, Name = "Science", DisplayOrder = 2, Description = "Khoa Hoc" },
                new Category { Id = 6, Name = "History", DisplayOrder = 2, Description = "Lich Su" }
                );
        }
    }
}
