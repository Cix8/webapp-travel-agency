using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {
        private TravelAgencyContext _ctx;
        public TravelPackageController()
        {
            _ctx = new TravelAgencyContext();
        }

        [HttpGet]
        public IActionResult Get(string? searchKey)
        {
            IQueryable<TravelPackage> packages = _ctx.TravelPackages;
            if(searchKey != null)
            {
                packages = packages.Where(pack => pack.Title.Contains(searchKey));
            }
            packages = packages.Include("Destinations");
            return Ok(packages.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            TravelPackage package = _ctx.TravelPackages.Where(pack => pack.Id == id).Include("Destinations").FirstOrDefault();
            if(package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }
    }
}
