using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            List<TravelPackage> packages = _ctx.TravelPackages.ToList();
            return Ok(packages);
        }
    }
}
