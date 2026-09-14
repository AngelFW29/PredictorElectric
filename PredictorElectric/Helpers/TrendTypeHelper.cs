using PredictorElectric.Business.Enums;

namespace PredictorElectric.Helpers
{
    public static class TrendTypeHelper
    {
        public static string ToTrendWording(TrendType trend) => trend switch
        {
            TrendType.RISING => "Alcista",
            TrendType.FALLING => "Bajista",
            TrendType.STABLE => "Estable",
            _ => trend.ToString()
        };
        public static string ToChangeWording(TrendType trend) => trend switch
        {
            TrendType.RISING => "Aumentando",
            TrendType.FALLING => "Disminuyendo",
            TrendType.STABLE => "Estable",
            _ => trend.ToString()
        };
    }
}
