using PredictorElectric.Business.Dtos;
using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Services
{
    public class SmaService :  IPredictionService<SmaDto>
    {
        public SmaDto CalculateResult(List<MonthlyConsumptionDto> consumptions)
        {
            var lastThreeConsumptions = consumptions.TakeLast(3).Select(c => c.Consumption).ToList();

            double avgLastThree = lastThreeConsumptions.Average();
            var lastConsumption = consumptions.Last().Consumption;

            TrendType trend = avgLastThree > lastConsumption ? TrendType.RISING
                     : avgLastThree < lastConsumption ? TrendType.FALLING
                     : TrendType.STABLE;

            return new SmaDto
            {
                AvgConsumption = avgLastThree,
                Tendency = trend
            };
        }
    }
}
