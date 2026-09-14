using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Dtos
{
    public class SmaDto
    {
        public required double AvgConsumption { get; set; }
        public required TrendType Tendency { get; set; }
    }
}
