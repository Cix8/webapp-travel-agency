using Microsoft.Data.SqlClient.Server;
using webapp_travel_agency.Db_Context;
using webapp_travel_agency.Models.Repository.Interfaces;

namespace webapp_travel_agency.Models.Repository
{
    public class DestinationRepository : IDestinationRepo
    {
        private TravelAgencyContext _ctx;
        public DestinationRepository(TravelAgencyContext _context)
        {
            _ctx = _context;
        }
        public List<Destination> GetList()
        {
            List<Destination> destinations = _ctx.Destinations.ToList();
            return destinations;
        }

        public List<Destination> GetSelectedDestinations(List<int> selectedDest)
        {
            List<Destination> destinations = _ctx.Destinations.Where(dest => selectedDest.Contains(dest.Id)).ToList();
            return destinations;
        }
    }
}
