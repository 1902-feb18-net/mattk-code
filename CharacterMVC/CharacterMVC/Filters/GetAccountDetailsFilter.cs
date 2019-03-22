using CharacterMVC.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CharacterMVC.Filters
{
    public class GetAccountDetailsFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (context.Controller is AServiceController controller)
            {
                var request = controller.CreateRequestToService(HttpMethod.Get,
                    "/api/account/details");

                var response = await controller.HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                }
                else
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    var details = JsonConvert.DeserializeObject<ApiAccountDetails>(jsonString);
                    controller.ViewData["accountDetails"] = details;
                    controller.AccountDetails = details;
                }
            }


            await next();
        }
    }
}
