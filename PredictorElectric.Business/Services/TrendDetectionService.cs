using PredictorElectric.Business.Dtos;
using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Services
{
    public class TrendDetectionService : IPredictionService<TrendDetectionDto>
    {
        public TrendDetectionDto CalculateResult(List<MonthlyConsumptionDto> consumptions)
        {
            int increased = 0;
            int decreased = 0;
            int stable = 0;

            for (int i = 1; i < consumptions.Count; i++)
            {
                if (consumptions[i].Consumption > consumptions[i - 1].Consumption)
                {
                    increased += 1;
                }
                else if (consumptions[i].Consumption < consumptions[i - 1].Consumption)
                {
                    decreased += 1;
                }
                else
                {
                    stable += 1;
                }
            }


            TrendType trend = increased > decreased && increased > stable ? TrendType.RISING
                     : decreased > increased && decreased > stable ? TrendType.FALLING
                     : TrendType.STABLE;

            return new TrendDetectionDto
            {
                IncreasedMonthsCount = increased,
                DecreasedMonthsCount = decreased,
                StableMonthsCount = stable,
                Tendency = trend
            };
        }
    }
}
