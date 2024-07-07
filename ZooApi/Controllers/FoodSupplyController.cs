using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApi.Repository;

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodSupplyController : ControllerBase
    {
        private readonly IZooRepository _zooRepository;

        public FoodSupplyController(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        [HttpGet]
        public IActionResult GetFoodSupply()
        {
            return Ok(_zooRepository.GetZoo().FoodSupply);
        }

        [HttpPost("add")]
        public IActionResult AddFood([FromBody] double amount)
        {
            _zooRepository.AddFood(amount);
            return Ok();
        }

        [HttpPost("feed")]
        public IActionResult FeedAnimals()
        {
            _zooRepository.FeedAnimals();
            return Ok();
        }
    }
}
