using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HelloMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // in Visual Studio...
            // we have "IIS Express" web server.
            //  web servers are software that listen on ports
            //  for data sent over internet, especially HTTP
            //  our application runs inside/alongside that web server.
            //  technically we have another web server that is a contianer
            //  directly for this application called Kestrel.
            //  Kestrel is cross-platform, IIS is Windows only
            CreateWebHostBuilder(args).Build().Run();
        }



        // ASP.NET creates a webhost and runs it, using configuration given by
        // Startup class.
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
