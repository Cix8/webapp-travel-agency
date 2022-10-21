namespace webapp_travel_agency.Models.Repository.Interfaces
{
    public interface IDestinationRepo
    {
        public List<Destination> GetList();
        public List<Destination> GetSelectedDestinations(List<int> selectedDest);

    }
}
