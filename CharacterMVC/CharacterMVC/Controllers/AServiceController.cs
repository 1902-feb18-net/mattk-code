using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMVC.Controllers
{
    public abstract class AServiceController : Controller
    {
        public HttpClient HttpClient { get; }
        public Uri ServiceUrl { get; }
        public string ServiceCookieName { get; }

        public ApiAccountDetails AccountDetails { get; set; }

        public AServiceController(HttpClient httpClient, IConfiguration configuration)
        {
            HttpClient = httpClient;
            ServiceUrl = new Uri(configuration["ServiceUrl"]);
            ServiceCookieName = configuration["ServiceCookieName"];
        }

        public HttpRequestMessage CreateRequestToService(HttpMethod method, string relativeUrl, object body = null)
        {
            var url = new Uri(ServiceUrl, relativeUrl);
            var apiRequest = new HttpRequestMessage(method, url);

            if (body != null)
            {
                var jsonString = JsonConvert.SerializeObject(body);
                apiRequest.Content = new StringContent(jsonString, Encoding.UTF8,
                    "application/json");
            }

            var cookieValue = Request.Cookies[ServiceCookieName];

            if (cookieValue != null)
            {
                //apiRequest.Headers.Add("Cookie", new CookieHeaderValue(ServiceCookieName, cookieValue));
                //apiRequest.Headers.Add("Cookie", )
            }
        }

    }
}
