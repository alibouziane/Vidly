using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(c => c.Genre).ToList();


            return View(movies);
        }


        public ActionResult Details(int id)

        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}

            };
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie
            {

                Name = "Shrek!"
            };


            var custmers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = custmers
            };

            return View(viewModel);
            //ViewBag.Movie = movie;
            //ViewData["Randommovie"] = movie;//do not use please
            //var viewResult = new ViewResult();
            // movie will be asssigned to 
            //viewResult.ViewData.Model//viedatadictionary


        }

        //public ActionResult Edit(int id)
        //{

        //    return Content("id= " + id);


        //}

        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(string.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));

        //}


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();


            var viewmModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewmModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException  e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index", "Movies");
        }

    }
}