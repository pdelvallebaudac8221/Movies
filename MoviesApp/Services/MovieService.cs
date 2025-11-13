using MoviesApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Services;

public class MovieService : IMovieService
{

    private MovieDbContext _context;

    public MovieService(MovieDbContext movieDbContext)
    {
        _context = movieDbContext;
    }

    // 1. Get list of all movies
    public List<Movie> GetAllMovies()
    {
        return _context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
    }

    // 2. Get list of genres
    public List<Genre> GetAllGenres()
    {
        return _context.Genres.OrderBy(g => g.Name).ToList();
    }

    // 3. Add a new movie and return its Id
    public int AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return movie.MovieId;
    }
    
    // 4. Get a movie by Id
    public Movie? GetMovieById(int id)
    {
        return _context.Movies.Find(id);
    }

    // 5. Update an existing movie
    public void UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }

    // 6. Delete a movie
    public void DeleteMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }
}