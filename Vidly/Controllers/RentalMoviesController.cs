using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalMoviesController : Controller
    {
        private ApplicationDbContext _context;

        public RentalMoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: RentalMovies
        public ActionResult Index()
        {
            var customers = _context.Customers.Local.ToList();
            var movies = _context.Movies.ToList();


            return View();
        }
    }
}