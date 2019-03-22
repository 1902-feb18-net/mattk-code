using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesSite.BLL;
using MoviesSite.DataAccess;

namespace MoviesSite.App
{
    public class Startup
    {
        public static readonly List<Movie> _moviesDb = new List<Movie>();
        public static readonly List<Genre> _genreDb = new List<Genre>();

        private static void SeedDatabase()
        {
            _genreDb.AddRange(new[]
            {
                new Genre{ Id = 1, Name = "Action"},
                new Genre{ Id = 1, Name = "Drama"},

            });

            _moviesDb.AddRange(new[]
            {
                new Movie
                {
                    Id = 1,
                    Title = "Star Wars IV",
                    DateReleased = new DateTime(1970, 1, 1),
                    Genre = _genreDb[0]
                }
            });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SeedDatabase();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<MovieRepository>();
            services.AddSingleton<IList<Movie>>(_moviesDb);
            services.AddSingleton<IList<Genre>>(_genreDb);

            services.AddDbContext<MovieDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("MovieDB")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
