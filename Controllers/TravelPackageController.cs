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
            TravelDestination model = new TravelDestination();
            model.Destinations = _ctx.Destinations.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelDestination formData)
        {
            if(!ModelState.IsValid)
            {
                formData.Destinations = _ctx.Destinations.ToList();
                return View(formData);
            }

            formData.Package.Destinations = _ctx.Destinations.Where(dest => formData.SelectedDestinations.Contains(dest.Id)).ToList();
            _ctx.TravelPackages.Add(formData.Package);
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
