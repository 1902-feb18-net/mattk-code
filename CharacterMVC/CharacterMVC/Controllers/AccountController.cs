using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CharacterMVC.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharacterMVC.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration)
        { }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApiLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            // httpClient?

            var request = CreateRequestToService(HttpMethod.Post, "/api/account/login", login);

            var response = await HttpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ModelState.AddModelError("", "Login or password incorrect.");
                    return View();
                }
                ModelState.AddModelError("", "Unexpected server error.");
                return View();

            }

            var success = PassCookiesToClient(response);
            if (!success)
            {
                ModelState.AddModelError("", "Unexpected server error.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }


        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out var values))
            {
                var headerValue = values.FirstOrDefault(x => x.StartsWith(ServiceCookieName));
                if (headerValue != null)
                {
                    Response.Headers.Add("Set-Cookie", headerValue);
                    return true;
                }
            }
            return false;
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}