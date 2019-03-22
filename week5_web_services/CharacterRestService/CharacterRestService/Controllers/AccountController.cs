using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterRestDAL;
using CharacterRestService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CharacterRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public SignInManager<IdentityUser> SignInManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public AccountController(SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AuthDBContext dbContext)
        {
            SignInManager = signInManager;
            RoleManager = roleManager;

            dbContext.Database.EnsureCreated();

           


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await SignInManager.PasswordSignInAsync(
                login.Username, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return NoContent();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register, 
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser(register.Username);

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            
            if (!await RoleManager.RoleExistsAsync("admin"))
            {
                var role = new IdentityRole("admin");
                var result2 = await RoleManager.CreateAsync(role);

                if (!result2.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to create admin role");

                }
            }

            var result3 = await userManager.AddToRoleAsync(user, "admin");
            if (!result3.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to create admin role");

            }


            await SignInManager.SignInAsync(user, false);

            return NoContent();

        }

    }
}