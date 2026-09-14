using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Dtos
{
    public class LinearRegressionDto
    {
        public required double EstimatedConsumption { get; set; }
        public required double Slope { get; set; }
        public required TrendType Tendency { get; set; }
    }
}
