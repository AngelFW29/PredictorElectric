using System.ComponentModel.DataAnnotations;

namespace PredictorElectric.Business.Validations
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public NotFutureDateAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;
            if (date > DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
