using MoviesApp.Entities;

namespace MoviesApp.Services;

public interface IMovieService
{
    // Our methods to talk to the database
    // 1. Get list of all movies
    public List<Movie> GetAllMovies();
    // 2. Get list of genres
    public List<Genre> GetAllGenres();
    // 3. Add a new movie and return its Id
    public int AddMovie(Movie movie);
    // 4. Get a movie by Id
    public Movie? GetMovieById(int id);
    // 5. Update an existing movie
    public void UpdateMovie(Movie movie);
    // 6. Delete a movie
    public void DeleteMovie(Movie movie);

}