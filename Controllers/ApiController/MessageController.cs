using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private TravelAgencyContext _ctx;
        public MessageController()
        {
            _ctx = new TravelAgencyContext();
        }

        [HttpPost("{id}")]
        public IActionResult Send(int id, Message message)
        {
            TravelPackage package = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();
            if(package == null)
            {
                return NotFound();
            }
            message.TravelPackageId = id;
            _ctx.Messages.Add(message);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
