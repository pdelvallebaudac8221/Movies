using Microsoft.AspNetCore.Mvc;

using MoviesApp.Entities;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        // Add a constructor that accepts a db context object:
        public MoviesController(MovieDbContext movieDbContext)
        {
            // assign it to our private data field so that it is avaliable for use in action methods:
            _movieDbContext = movieDbContext;
        }

        public IActionResult List()
        {
            // Use the db conext object to query for all our movies from the DB
            // and order them by name:
            List<Movie> movies = _movieDbContext.Movies.OrderBy(m => m.Name).ToList();

            // and pass that list off to the view:
            return View(movies);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            // return an initialized movie object:
            return View(new Movie());
        }

        // and the POST version that has a Movie param that
        // ASP.NET binding creates for us based on the incoming
        // URL encoded data in the POST body using the binding rules
        // and then passes it to our controller
        [HttpPost()]
        public IActionResult Create(Movie movie)
        {
            // check validity first 
            if (ModelState.IsValid)
            {
                // it's valid using the db context object 
                // we add the movie to the DB & dave changes:
                _movieDbContext.Movies.Add(movie);
                _movieDbContext.SaveChanges();

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
        public IActionResult Delete(int id)
        {
            var movie = _movieDbContext.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieDbContext.Movies.Remove(movie);
            _movieDbContext.SaveChanges();
            return RedirectToAction("List", "Movies");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _movieDbContext.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            // check validity first 
            if (ModelState.IsValid)
            {
                // it's valid using the db context object 
                // we add the movie to the DB & dave changes:
                _movieDbContext.Movies.Update(movie);
                _movieDbContext.SaveChanges();

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
        
        private MovieDbContext _movieDbContext;
    }
}
