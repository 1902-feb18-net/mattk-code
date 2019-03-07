using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // now we know how to print/read data
            // we could access some UserRepository here
            // which accesses some DbContext
            var user = new User {
                Username = "Fred",
                   Address = new List<Address>
                   {
                       new Address {  Street = "123 Main St", CityState = "Reston, VA"},
                       new Address {  Street = "321 Broad St", CityState = "Dallas, TX"}
                   }
            };
            return View(user);
        }

        public IActionResult IndexWithId(int id)
        {
            var user = new User { Username = $"Fred #{id}" };
            // the View() method defined on parent class Controller
            // looks for a View with the name of the current method
            // this won't work there is no 
            //return View("Index");
            return View("Index", user);
        }

        [HttpPost] // this method receives POST, not GET
        public IActionResult IndexWithUser(User user)
        {
            // we're going to receive form data, and "model binding" will occur
            // to this "user" object.
            return View("Index", user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
