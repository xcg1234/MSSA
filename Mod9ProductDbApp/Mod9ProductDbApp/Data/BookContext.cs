using Microsoft.EntityFrameworkCore;
using Mod9ProductDbApp.Models;

namespace Mod9ProductDbApp.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(GetBooks());
        }

        private static Book[] GetBooks()
        {
            return new[]
            {
                new Book
                {
                    ISBN = "9780132350884",
                    Name = "Clean Code",
                    AuthorName = "Robert C. Martin",
                    Description = "A handbook of agile software craftsmanship."
                }
            };
        }
    }
}
