using PredictorElectric.Business.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PredictorElectric.Business.Validations
{
    public class NoDuplicateDatesAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var list = value as List<MonthlyConsumptionViewModel>;

            if (list == null)
            {
                return ValidationResult.Success;
            }
            var dates = list.Select(m => m.Date);
            bool duplicates = dates.GroupBy(f => f).Any(grupo => grupo.Count() > 1);

            if (duplicates)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
