using Microsoft.EntityFrameworkCore;
using MoviesSite.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesSite.DataAccess
{
    // steps for code-first EF:
    // 1. have separate data access class library project
    // 2. add NuGet package Microsoft.EntityFrameworkCore.SqlServer
    // 3. implement your context class (inheriting from DbContext).
    //      a. neee constructor receiving DbContextOptions and zero parameter constructor
    //      b. need DbSets
    //      c. need OnModelCreating
    // 4. enable migrations
    //      (just like with the db-first scaffolding, there is "Package Manager Console" way
    //      and dotnet CLI 
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        { }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(builder =>
            {
                builder.HasKey(m => m.Id);

                builder.Property(m => m.Id)
                        .UseSqlServerIdentityColumn();

                builder.Property(m => m.Title)
                        .IsRequired()
                        .HasMaxLength(128);

                builder.Property(m => m.DateReleased)
                        .HasColumnType("DATETIME2");

                builder.HasOne(m => m.Genre)
                        .WithMany(g => g.Movies);
            });

            modelBuilder.Entity<Genre>(builder =>
            {

            });
        }
    }
}
