namespace webapp_travel_agency.Models.Repository.Interfaces
{
    public interface IPackageRepo
    {
        public List<TravelPackage> GetList(string includes = "");
        public TravelPackage GetPackageBy(int id, string includes="");
        public void AddPackage(TravelPackage package);
        public void RemovePackage(TravelPackage package);
        public void Save();
    }
}
