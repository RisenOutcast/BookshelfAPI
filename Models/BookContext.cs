// The main database context
// Controls the database's main table "Books" and configures the SQLite connection.
// Author: Metso (@RisenOutcast)

using Microsoft.EntityFrameworkCore;

namespace BookshelfAPI.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


        protected readonly IConfiguration Configuration;
        public BooksContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to SQLite database
            options.UseSqlite(Configuration.GetConnectionString("BooksDB"));
        }
    }
}
