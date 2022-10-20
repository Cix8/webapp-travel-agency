using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.CustomValidations
{
    public class DurationValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int fieldValue = (int)value;

            if (fieldValue <= 0)
            {
                return new ValidationResult("La durata non può essere negativa o uguale a zero");
            }

            return ValidationResult.Success;
        }
    }
}
