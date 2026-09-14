using System.ComponentModel.DataAnnotations;
using PredictorElectric.Business.Validations;

namespace PredictorElectric.Business.ViewModels
{
    public class MonthlyConsumptionViewModel
    {
        [Required(ErrorMessage = "Debe ingresar la fecha del consumo eléctrico")]
        [NotFutureDate(ErrorMessage = "La fecha del consumo eléctrico no puede ser futura")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Debe ingresar el consumo eléctrico")]
        [Range(0, double.MaxValue, ErrorMessage = "El consumo eléctrico no puede ser negativo")]
        public double? Consumption { get; set; }
    }
}
