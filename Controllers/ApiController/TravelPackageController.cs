using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Controllers.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {
        private IPackageRepo _packageRepo;

        public TravelPackageController(IPackageRepo _packRepo)
        {
            _packageRepo = _packRepo;
        }

        [HttpGet]
        public IActionResult Get(string? searchKey)
        {
            List<TravelPackage> packages = _packageRepo.GetFilteredList(searchKey);
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            TravelPackage package = _packageRepo.GetPackageBy(id, "Destinations");
            if(package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }
    }
}
