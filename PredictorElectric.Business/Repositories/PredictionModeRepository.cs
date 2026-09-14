using PredictorElectric.Business.Enums;

namespace PredictorElectric.Business.Repositories
{
    public sealed class PredictionModeRepository
    {
        private PredictionModeRepository() { }

        public static PredictionModeRepository Instance { get; } = new (); 
        public PredictionMode CurrentMode { get; set; } = PredictionMode.SMA;
    }
}
