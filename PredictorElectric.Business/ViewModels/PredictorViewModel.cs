namespace PredictorElectric.Business.ViewModels
{
    public class PredictorViewModel
    {
        public MonthlyConsumptionListViewModel ConsumptionData { get; set; } = new();
        public PredictionResultViewModel? PredictionResult { get; set; }
    }
}
