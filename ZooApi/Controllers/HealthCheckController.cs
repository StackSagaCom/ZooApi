using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }
    }
}
