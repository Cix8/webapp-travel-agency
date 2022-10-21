using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Controllers.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IPackageRepo _packageRepo;
        private IMessageRepo _messageRepo;

        public MessageController(IPackageRepo _packRepo, IMessageRepo _mexRepo)
        {
            _packageRepo = _packRepo;
            _messageRepo = _mexRepo;
        }

        [HttpPost("{id}")]
        public IActionResult Send(int id, Message message)
        {
            TravelPackage package = _packageRepo.GetPackageBy(id);
            if(package == null)
            {
                return NotFound();
            }
            message.TravelPackageId = id;
            _messageRepo.AddMessage(message);
            return Ok();
        }
    }
}
