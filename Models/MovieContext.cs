using Microsoft.EntityFrameworkCore;

namespace mission6assignment.Models
{
    public class MovieContext : DbContext // liaison from the app to the database
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) // constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Ensuring the schema is created only if it doesn't exist
        public void EnsureDatabaseCreated()
        {
            this.Database.EnsureCreated();
        }
    }
}
