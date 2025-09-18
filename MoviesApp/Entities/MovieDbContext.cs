using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Entities
{
    /// <summary>
    /// This our context class for interacting with the DB 
    /// and it inherits from the base DbContext. Note: we also
    /// define a constructor that accepts a option param that we simply
    /// pass up to the base class.
    /// </summary>
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        // Define a get/set property to access our Movie
        // objects from/to the DB:
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Overiding the base class version of this handler method
        /// that handles configuration you want/need to do as the
        /// DB is built.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here, let's seed the DB with some data:
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name = "Casablanca", Year = 1942, Rating = 5},
                new Movie() { MovieId = 2, Name = "Annie Hall", Year = 1977, Rating = 5 },
                new Movie() { MovieId = 3, Name = "Apocalypse Now", Year = 1979, Rating = 4 }
            );
        }
    }
}
