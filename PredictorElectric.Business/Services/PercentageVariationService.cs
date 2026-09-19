using PredictorElectric.Business.Dtos;
using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Services
{
    public class PercentageVariationService : IPredictionService<PercentageVariationDto>
    {
        public PercentageVariationDto CalculateResult(List<MonthlyConsumptionDto> consumptions)
        {
            var variations = new List<double?>();

            for (int i = 0; i < consumptions.Count; i++)
            {
                if (i == 0)
                {
                    variations.Add(null);
                }
                else
                {
                    if (consumptions[i - 1].Consumption == 0)
                    {
                        variations.Add(null);
                    }
                    else
                    {
                        var variation = ((consumptions[i].Consumption - consumptions[i - 1].Consumption) / consumptions[i - 1].Consumption) * 100;
                        variations.Add(variation);
                    }

                }
            }
            bool hasValidVariations = variations.Any(v => v != null);
            double? avgVariations = hasValidVariations
                ? variations.Where(vrt => vrt != null).Select(vrt => vrt!.Value).Average()
                : null;

            TrendType trend = avgVariations > 1 ? TrendType.RISING
                     : avgVariations < -1 ? TrendType.FALLING
                     : TrendType.STABLE;

            return new PercentageVariationDto
            {
                PercentageVariation = variations,
                AvgVariation = avgVariations,
                Tendency = trend
            };
        }
    }
}