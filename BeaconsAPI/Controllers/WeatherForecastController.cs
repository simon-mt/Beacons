using BeaconsDomain;
using Microsoft.AspNetCore.Mvc;

namespace BeaconsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeaconsController : ControllerBase
    {
        private readonly IBeaconsRepository _repo;

        public BeaconsController(IBeaconsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var beacons = new BeaconList()
            {
                Beacons = _repo.ReadAll()
            };
            
            return Ok(beacons);
        }

        [HttpPost]
        public IActionResult Create(Beacon item)
        {
            _repo.Create(item);
            return Ok();
        }
    }
}
