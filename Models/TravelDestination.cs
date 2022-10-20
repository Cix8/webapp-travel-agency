using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class TravelDestination
    {
        public TravelPackage Package { get; set; }
        public List<Destination> Destinations { get; set; }

        [Required(ErrorMessage = "Inserire almeno una destinazione")]
        public List<int> SelectedDestinations { get; set; }

        public TravelDestination()
        {
            Package = new TravelPackage();
            Destinations = new List<Destination>();
        }
    }
}
