using Microsoft.EntityFrameworkCore;

namespace mission6assignment.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) // constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
