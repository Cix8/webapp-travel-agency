using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Models.Repository
{
    public class PackageRepository : IPackageRepo
    {
        private TravelAgencyContext _ctx;
        public PackageRepository(TravelAgencyContext _context)
        {
            _ctx = _context;
        }

        public List<TravelPackage> GetList(string includes = "")
        {
            IQueryable<TravelPackage> packages = _ctx.TravelPackages;
            if(includes.Trim() != "")
            {
                string[] subIncludes = includes.Split(',');
                foreach(string sub in subIncludes)
                {
                    packages = packages.Include(sub.Trim());
                }
            }
            return packages.ToList();
        }

        public List<TravelPackage> GetFilteredList(string? key)
        {
            IQueryable<TravelPackage> packages = _ctx.TravelPackages;
            if (key != null)
            {
                packages = packages.Where(pack => pack.Title.Contains(key));
            }
            packages = packages.Include("Destinations");
            return packages.ToList();
        }

        public TravelPackage GetPackageBy(int id, string includes="")
        {
            IQueryable<TravelPackage> package = _ctx.TravelPackages.Where(pack => pack.Id == id);
            if (includes.Trim() != "")
            {
                string[] subIncludes = includes.Split(',');
                foreach (string sub in subIncludes)
                {
                    package = package.Include(sub.Trim());
                }
            }
            return package.FirstOrDefault();
        }

        public void AddPackage(TravelPackage package)
        {
            _ctx.TravelPackages.Add(package);
            this.Save();
        }

        public void RemovePackage(TravelPackage package)
        {
            _ctx.TravelPackages.Remove(package);
            this.Save();
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
