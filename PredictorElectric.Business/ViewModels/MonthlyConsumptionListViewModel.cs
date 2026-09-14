using PredictorElectric.Business.Validations;

namespace PredictorElectric.Business.ViewModels
{
    public class MonthlyConsumptionListViewModel
    {
        [NoDuplicateDates(ErrorMessage = "No se permiten fechas duplicadas, entre los meses.")]
        public  List<MonthlyConsumptionViewModel> MonthlyConsumptions { get; set; } =
        Enumerable.Range(0, 12).Select(_ => new MonthlyConsumptionViewModel()).ToList();

    }
}