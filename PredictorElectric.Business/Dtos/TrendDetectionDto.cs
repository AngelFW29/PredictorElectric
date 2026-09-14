using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Dtos
{
    public class TrendDetectionDto
    {
        public required int IncreasedMonthsCount { get; set; }
        public required int DecreasedMonthsCount { get; set; }
        public required int StableMonthsCount { get; set; }
        public required TrendType Tendency { get; set; }
    }
}
