using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models;
using webapp_travel_agency.Models.Repository;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class TravelPackageController : Controller
    {
        private IPackageRepo _packageRepo;
        private IDestinationRepo _destinationRepo;

        public TravelPackageController(IPackageRepo _packRepo, IDestinationRepo _destRepo)
        {
            _packageRepo = _packRepo;
            _destinationRepo = _destRepo;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<TravelPackage> packages = _packageRepo.GetList("Destinations, Messages");
            return View(packages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TravelDestination model = new TravelDestination();
            model.Destinations = _destinationRepo.GetList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelDestination formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Destinations = _destinationRepo.GetList();
                return View(formData);
            }

            formData.Package.Destinations = _destinationRepo.GetSelectedDestinations(formData);
            _packageRepo.AddPackage(formData.Package);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            TravelPackage thisPackage = _packageRepo.GetPackageBy(id, "Messages");
            if (thisPackage == null)
            {
                return NotFound("Pacchetto non trovato");
            }
            return View(thisPackage);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TravelDestination model = new TravelDestination();
            model.Package = _packageRepo.GetPackageBy(id, "Destinations"); 
            if (model.Package == null)
            {
                return NotFound("Pacchetto non trovato");
            }
            model.Destinations = _destinationRepo.GetList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, TravelDestination formData)
        {
            formData.Package.Id = id;

            if (!ModelState.IsValid)
            {
                formData.Destinations = _destinationRepo.GetList();
                return View(formData);
            }

            TravelPackage packageToUpdate = _packageRepo.GetPackageBy(id, "Destinations");
            if (packageToUpdate == null)
            {
                return NotFound("Pacchetto non trovato");
            }

            packageToUpdate.Title = formData.Package.Title;
            packageToUpdate.Description = formData.Package.Description;
            packageToUpdate.Cover = formData.Package.Cover;
            packageToUpdate.Price = formData.Package.Price;
            packageToUpdate.DurationInDays = formData.Package.DurationInDays;
            packageToUpdate.Destinations = _destinationRepo.GetSelectedDestinations(formData);

            _packageRepo.Save();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TravelPackage packToDelete = _packageRepo.GetPackageBy(id);

            if (packToDelete == null)
            {
                return NotFound("Non siamo riusciti a trovare il pacchetto che vuoi eliminare");
            }

            _packageRepo.RemovePackage(packToDelete);

            return RedirectToAction("Index");
        }
    }
}
