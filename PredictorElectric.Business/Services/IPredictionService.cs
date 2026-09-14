using PredictorElectric.Business.Dtos;

namespace PredictorElectric.Business.Services
{
    public interface IPredictionService<TResult>
    {
        TResult CalculateResult(List<MonthlyConsumptionDto> Consumptions); 
    }
}
