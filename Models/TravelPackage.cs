using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapp_travel_agency.CustomValidations;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La cover è obbligatoria")]
        [Column(TypeName = "text")]
        public string Cover { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [PriceValidation]
        public float Price { get; set; }

        [Required(ErrorMessage = "La durata è obbligatoria")]
        [DurationValidation]
        public int DurationInDays { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Message> Messages { get; set; }
        public TravelPackage()
        {
            Destinations = new List<Destination>();
            Messages = new List<Message>();
        }
    }
}
