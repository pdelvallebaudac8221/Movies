using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services;

using MoviesApp.Entities;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {

        // Our service object
        public IMovieService MovieService { get; set; }

        // Constructor that takes in the service object
        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public IActionResult List()
        {
            // Use the db conext object to query for all our movies from the DB
            // and order them by name:
            List<Movie> movies = MovieService.GetAllMovies();
            
            // and pass that list off to the view:
            return View(movies);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            // return an initialized movie object:
            ViewBag.Genres = MovieService.GetAllGenres();
            return View(new Movie());
        }

        // and the POST version that has a Movie param that
        // ASP.NET binding creates for us based on the incoming
        // URL encoded data in the POST body using the binding rules
        // and then passes it to our controller
        [HttpPost()]
        public IActionResult Create(Movie movie)
        {
            ViewBag.Genres = MovieService.GetAllGenres();
            // check validity first 
            if (ModelState.IsValid)
            {
                // it's valid, so using the service object
                // we add the movie to the DB & save changes:
                MovieService.AddMovie(movie);

                // redirect to the all movies view:
                return RedirectToAction("List", "Movies");
            }
            else
            {
                // invalid so simply return the movie to view
                // and validn errs will appear:
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = MovieService.GetMovieById(id);
            ViewBag.Genres = MovieService.GetAllGenres();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid) {

                // it's valid using the service object
                // we update the movie to the DB & save changes:
                MovieService.UpdateMovie(movie);

                // redirect to the all movies view:
                return RedirectToAction("List", "Movies");

            }
            else
            {
                // invalid so simply return the movie to view
                // and validn errs will appear:
                ViewBag.Genres = MovieService.GetAllGenres();
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = MovieService.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            MovieService.DeleteMovie(movie);
            return RedirectToAction("List", "Movies");
        }

        //private MovieDbContext _movieDbContext;
    }
}
