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
            // Read beacons list.
            var beacons = new BeaconList()
            {
                //Beacons = _repo.ReadAll()
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
