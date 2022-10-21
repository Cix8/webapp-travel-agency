using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private TravelAgencyContext _ctx;

        public MessageController()
        {
            _ctx = new TravelAgencyContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Message> messages = _ctx.Messages.Include("TravelPackage").ToList(); 
            return View(messages);
        }
    }
}
