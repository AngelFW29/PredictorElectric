using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Dtos
{
    public class PercentageVariationDto
    {
        public required List<double?> PercentageVariation { get; set; }
        public required double AvgVariation { get; set; }
        public required TrendType Tendency { get; set; }
    }
}
