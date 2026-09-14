using PredictorElectric.Business.Dtos;
using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Services
{
    public class LinearRegressionService : IPredictionService<LinearRegressionDto>
    {
        public LinearRegressionDto CalculateResult(List<MonthlyConsumptionDto> consumptions)
        {
            var y = consumptions.Select(c => c.Consumption).ToList();
            var x = Enumerable.Range(1, 12).ToList();


            double sumX = x.Sum(); 
            double sumY = y.Sum();
            double sumProductXY = sumX * sumY; 

            double sumX2 = x.Select(xValue => xValue * xValue).Sum();

            double sumXY = x.Zip(y, (xValue, yValue) => xValue * yValue).Sum();

            var m = (12 * sumXY - sumProductXY) / (12 * sumX2 - (sumX * sumX));

            var b = y.Average() - m * x.Average();

            var estimatedPrediction = m * 13 + b;

            TrendType trend = m > 0 ? TrendType.RISING
                     : m < 0 ? TrendType.FALLING
                     : TrendType.STABLE;

            return new LinearRegressionDto
            {
                EstimatedConsumption = estimatedPrediction,
                Tendency = trend,
                Slope = m
            };
        }
    }
}
