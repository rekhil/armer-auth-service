using Microsoft.AspNetCore.Mvc;

namespace Armer.Auth.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API is running successfully";
        }
    }
}
