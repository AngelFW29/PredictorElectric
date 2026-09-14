using PredictorElectric.Business.Dtos;

namespace PredictorElectric.Business.ViewModels
{
    public class PredictionResultViewModel
    {
        public SmaDto? SmaResult { get; set; }
        public LinearRegressionDto? LinearRegressionResult { get; set; }
        public PercentageVariationDto? PercentageVariationResult { get; set; }
        public TrendDetectionDto? TrendDetectionResult { get; set; }
    }
}