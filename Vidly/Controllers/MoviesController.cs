using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using Vidly.Controllers.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new List<Movie>
            {
                new Movie { Name = "Test"},
                new Movie {Name = "Test1" }

            };
            var customer = new List<Customer>
            {

                new Customer { Name = "Bhanu"},
                new Customer { Name = "Kanchan"}
            };

            var viewModel = new RandomMovieViewModel
            {
               // Movie = movie,
                Customers = customer

            };

            return View(viewModel) ;
        }

        

        public ActionResult PageIndex(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content( String.Format("pageIndex={0}&sortBy={1}" , pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index", movies);
            

            return View("ReadOnlyIndex", movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new MovieViewModel
            {
                Genre = genre
            };

            return View("New",viewModel);
        }
        public ActionResult Details(int? id)
        {
            //var movies = _context.Movies.SingleOrDefault(m => m.Id == );

            if (id == 0)
                return new HttpNotFoundResult();
            //var id = 1;
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return new HttpNotFoundResult();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
              //  movie = _context.Movies.ToList();
                var genre = _context.Genre.ToList(); 
                var viewModel = new MovieViewModel()
                {
                        Movie = movie,
                        Genre = genre
                };
                return View("New",viewModel);

            }    
                     
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id == id);
            var genre = _context.Genre.ToList();

            if (movie == null)
            {
                return new HttpNotFoundResult();
            }

            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genre=genre
            };
            ViewBag.IsInEditMode = true;
            return View("New", viewModel);
        }

        
        
    }
}