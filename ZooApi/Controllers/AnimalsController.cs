using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ZooService _zooService;

        public AnimalsController(ZooService zooService)
        {
            _zooService = zooService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_zooService.GetAnimals());
        }

        [HttpGet("{type}")]
        public IActionResult GetAnimalsByType(string type)
        {
            return Ok(_zooService.GetAnimalsByType(type));
        }

    }
}
