using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSite.App.ViewModels;
using MoviesSite.BLL;

namespace MoviesSite.App.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController(MovieRepository movieRepo)
        {
            MovieRepo = movieRepo;
        }

        public MovieRepository MovieRepo { get; set; } 

        // two steps to setup dependency injection
        // 1. register the dep. as a service in STartup.ConfigureServices.
        // 2. request the service (typically, by just having it as ctor parameter)

        
        // GET: Movies
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = MovieRepo.AllMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = MovieRepo.MovieById(id);

            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.DateReleased,
                Genre = movie.Genre,
                Genres = MovieRepo.AllGenres().ToList()

            };

            return View(movie);

        }

        // GET: Movies/Create
        public ActionResult Create()
        {

            var viewModel = new MovieViewModel
            {
                Genres = MovieRepo.AllGenres().ToList()
        };
            return View(viewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel viewModel)
        {
            try
            {

                var movie = new Movie
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    DateReleased = viewModel.ReleaseDate,
                    Genre = viewModel.Genre

                };

                // TODO: Add insert logic here
                MovieRepo.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Movie movie = MovieRepo.MovieById(id);
                return View(movie);
            }
            catch (InvalidOperationException)
            {
                // log that, and redirect to error page
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieViewModel viewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                var movie = new Movie
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    DateReleased = viewModel.ReleaseDate,
                    Genre = viewModel.Genre

                };

                // TODO: Add insert logic here
                MovieRepo.Create(movie);
                return RedirectToAction(nameof(Index));
            }

                
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = MovieRepo.MovieById(id);
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                MovieRepo.DeleteMovie(movie.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
    }
}