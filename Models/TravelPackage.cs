using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapp_travel_agency.CustomValidations;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column(TypeName = "text")]
        public string Cover { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [PriceValidation]
        public float Price { get; set; }


        public TravelPackage()
        {

        }
    }
}
