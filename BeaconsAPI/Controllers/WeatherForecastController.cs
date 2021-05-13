using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeaconsDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetBeaconByName([FromRoute] String name)
        {
            var beacons = new BeaconList()
            {
                Beacons = _repo.ReadByName(name)
            };

            return Ok(beacons);
        }

        [HttpGet]
        [Route("Status")]
        public IActionResult GetBeaconByActivated([FromQuery] Boolean activated)
        {
            var beacons = new BeaconList()
            {
                Beacons = _repo.ReadByActivated(activated)
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
