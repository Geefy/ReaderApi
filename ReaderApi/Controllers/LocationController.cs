using Microsoft.AspNetCore.Mvc;
using ReaderApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private LocationRepository locationRepository;
        public LocationController(LocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            try
            {
                var locations = locationRepository.GetAllLocations();
                return Ok(locations);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong in GetAllLocations");
                throw;
            }
        }
    }
}
