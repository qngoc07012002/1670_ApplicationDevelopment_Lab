using _1670_ApplicationDevelopment_Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace _1670_ApplicationDevelopment_Lab.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
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
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Programming", Description = "Basic Start", Author = "Microsoft", Price = 10.5, CategoryId = 1 },
                new Book { Id = 2, Title = "App Dev", Description = "Appppp DEVVVV", Author = "Nguyen Quang Ngoc", Price = 20, CategoryId = 2 },
                new Book { Id = 3, Title = "Python", Description = "Basic Python", Author = "Ngoc Nguyen Quang", Price = 40, CategoryId = 3 },
                new Book { Id = 4, Title = "C#", Description = "Start C#", Author = "Quang Ngoc", Price = 30, CategoryId = 4 }
                );
        }
    }
}
