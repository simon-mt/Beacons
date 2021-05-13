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


        public BeaconsController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Read beacons list.
            var beacons = new BeaconList();

            return Ok(beacons);
        }

        [HttpPost]
        public IActionResult Create(Beacon item) => _repo.Create(item) ? Ok() : BadRequest();
    }
}
