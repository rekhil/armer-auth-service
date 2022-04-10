using Microsoft.AspNetCore.Mvc;

namespace armer_auth_service.Controllers
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
