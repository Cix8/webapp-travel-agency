using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }
        public List<TravelPackage> TravelPackages { get; set; }
        public Destination()
        {

        }
    }
}
