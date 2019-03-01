using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloEntityFramework.DataAccess
{
    public class MovieRepo : IMovieRepo
    {
        public static MoviesContext myDbContext { get; set; }
        // we have a DbSet.Update()
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);

        MovieRepo(MoviesContext dbContext)
        {
            myDbContext = dbContext;
        }

        public static IEnumerable<Movie> GetAllMovies()
        {
            return myDbContext.Movie.ToList();
        }

        public static IEnumerable<Genre> GetAllGenres()
        {
            return myDbContext.Genre.ToList();
        }

        public static Movie GetMovieById(int id)
        {
            return myDbContext.Movie.Single(m => m.MovieId == id);
        }

        public static IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            return myDbContext.Movie.ToList().Where(m => m.Genre == genre);
        }

        void AddMovie(Movie movie);
        public static void AddMovie(Movie movie)
        {
            Genre actionGenre = dbContext.Genre.First(g => g.Name.Contains("Action"));

            Movie newMovie = new Movie
            {
                Title = "LOTR: The Two Towers",
                ReleaseDate = new DateTime(2003, 1, 1),
                Genre = actionGenre
            };

            // tell the dbcontext we have a new movie to insert.
            dbContext.Movie.Add(newMovie);

            // this one actually accesses the sql server and runs insert
            dbContext.SaveChanges();
        }


        static void UpdateMovies(MoviesContext dbContext)
        {
            foreach (var movie in dbContext.Movie)
            {
                movie.ReleaseDate = movie.ReleaseDate.AddYears(1);
            }

            dbContext.SaveChanges();
        }

        

        static void PrintMovies(MoviesContext dbContext)
        {
            foreach (var movie in dbContext.Movie)
            {
                Console.WriteLine($"Movie #{movie.MovieId}: ${movie.Title}" +
                    $" ({movie.ReleaseDate.Year})");
            }
        }


        static void DeleteAMovie(MoviesContext dbContext)
        {
            var movieToDelete = dbContext.Movie
                .OrderByDescending(x => x.ReleaseDate)
                .First();

            dbContext.Movie.Remove(movieToDelete);
            dbContext.SaveChanges();
        }

    }
}
