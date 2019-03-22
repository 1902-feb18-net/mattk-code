using HelloEntityFramework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloEntityFramework
{
    public interface IMovieRepo
    {
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Movie> GetAllGenres();
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetMoviesByGenre(Genre genre);
        void AddMovie(Movie movie);
        // we have a DbSet.Update()
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
    }
}
