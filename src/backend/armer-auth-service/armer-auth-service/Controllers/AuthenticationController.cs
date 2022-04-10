using Armer.Auth.Service.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Armer.Auth.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor of class AuthenticationController
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_roleManager"></param>
        /// <param name="_configuration"></param>
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Method to register new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Email);

            if (userExist != null)
                return BadRequest(new Response { Status = "Failed", Message = "User already exist" });

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return Ok(new Response { Status = "Failed", Message = $"User creation failed. {JsonConvert.SerializeObject(result.Errors, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })}" });

            return Ok(new Response { Status = "Success", Message = "User created successfully" });
        }
    }
}