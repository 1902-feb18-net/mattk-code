using HelloEntityFramework.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelloEntityFramework
{
    class Program
    {

        // EF database-first approach steps:
        //
        // 1. have startup project, and data access library project.
        // 2. reference data access from startup project.
        // 3. add NuGet packages to the startup project
        //      Microsoft.EntityFrameworkCore.Tools
        //      Microsoft.EntityFrameworkCore.SqlServer
        // 4. open Package Manager Console in VS
        //      ( View -> Other Windows -> Package Manager Console)
        // 5. run command:
        //      Scaffold-DbContext "<your-connection-string>" 
        //      Microsoft.EntityFrameworkCore.SqlServer
        //      -Project <name-of-data-project>
        // 6. delete the OnConfiguring override in the DbContext, to prevent
        //      committing your connection string to git.
        // (7. any time we change the database (add a new column, etc.), go to step 4.)

        // by default, the scaffolding will configure the models in OnModelCreating
        // with the fluent API. this is the right way to do it - strongest separation
        // of concerns, more flexibility.
        // if we scaffold with option "-DataAnnotations" we'll put the configuration
        // on the Movie and Genre classes themselves with attributes.

        //Scaffold-DbContext "Server=tcp:kagel1902sql.database.windows.net,1433;Initial Catalog=Movies;Persist Security Info=False;User ID=<>;Password=<>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -Project HelloEntityFramework.DataAccess -Force

        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;


            using (var dbContext = new MoviesContext(options))
            {
                var myMovieRepo = new MovieRepo(dbContext);

                // lots of complex setup... here is where the payoff begins
                PrintMovies(dbContext);
                Console.WriteLine();

                AddMovie(dbContext);

                PrintMovies(dbContext);

                UpdateMovies(dbContext);
            }

            Console.ReadLine();

        }

        

    }
}
