using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private IMessageRepo _messageRepo;

        public MessageController(IMessageRepo _mexRepo)
        {
            _messageRepo = _mexRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Message> messages = _messageRepo.GetList("TravelPackage");
            return View(messages);
        }
    }
}
