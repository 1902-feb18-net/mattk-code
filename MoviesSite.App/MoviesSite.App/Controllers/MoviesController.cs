using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSite.BLL;

namespace MoviesSite.App.Controllers
{
    public class MoviesController : Controller
    {
        public static readonly List<Movie> _moviesDb = new List<Movie>();
        public static readonly List<Genre> _genreDb = new List<Genre>();

        public MovieRepository MovieRepo { get; set; } =
            new MovieRepository(_moviesDb, _genreDb);
        
        // GET: Movies
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = MovieRepo.AllMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                MovieRepo.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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