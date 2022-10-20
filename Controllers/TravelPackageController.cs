using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class TravelPackageController : Controller
    {
        private TravelAgencyContext _ctx;

        public TravelPackageController()
        {
            _ctx = new TravelAgencyContext();
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<TravelPackage> packages = _ctx.TravelPackages.ToList();
            return View(packages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TravelPackage newPackage = new TravelPackage();
            return View(newPackage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelPackage formData)
        {
            if(!ModelState.IsValid)
            {
                return View(formData);
            }

            _ctx.TravelPackages.Add(formData);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            TravelPackage thisPackage = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();
            if(thisPackage == null)
            {
                return NotFound("Pacchetto non trovato");
            }
            return View(thisPackage);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TravelPackage packageToUpdate = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();
            if(packageToUpdate == null)
            {
                return NotFound("Pacchetto non trovato");
            }
            return View(packageToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, TravelPackage formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            TravelPackage packageToUpdate = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();
            if(packageToUpdate == null)
            {
                return NotFound("Pacchetto non trovato");
            }

            packageToUpdate.Title = formData.Title;
            packageToUpdate.Description = formData.Description;
            packageToUpdate.Cover = formData.Cover;
            packageToUpdate.Price = formData.Price;

            _ctx.SaveChanges();

            return RedirectToAction("Details", new {id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TravelPackage packToDelete = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();

            if (packToDelete == null)
            {
                return NotFound("Non siamo riusciti a trovare il pacchetto che vuoi eliminare");
            }

            _ctx.Remove(packToDelete);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
