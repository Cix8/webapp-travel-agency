using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il messaggio è obbligatorio")]
        [Column(TypeName = "text")]
        public string Content { get; set; }
        public int TravelPackageId { get; set; }
        public TravelPackage TravelPackage { get; set; }

        public Message()
        {

        }
    }
}
