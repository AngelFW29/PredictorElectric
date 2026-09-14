using Microsoft.AspNetCore.Mvc;
using PredictorElectric.Business.Dtos;
using PredictorElectric.Business.Enums;
using PredictorElectric.Business.Repositories;
using PredictorElectric.Business.ViewModels;
using PredictorElectric.Business.Services;

namespace PredictorElectric.Controllers
{
    public class PredictorController : Controller
    {
        public IActionResult Index()
        {
            return View(new PredictorViewModel());
        }
        public IActionResult Modos()
        {
            var vm = new PredictionModeViewModel
            {
                SelectedMode = PredictionModeRepository.Instance.CurrentMode
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult CalculatePrediction(PredictorViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            var consumptionDtos = vm.ConsumptionData.MonthlyConsumptions
                .Select(m => new MonthlyConsumptionDto
                {
                    Date = m.Date!.Value,
                    Consumption = m.Consumption!.Value
                }).ToList();

            var currentMode = PredictionModeRepository.Instance.CurrentMode;
            var result = new PredictionResultViewModel();

            switch (currentMode)
            {
                case PredictionMode.SMA:
                    var sma = new SmaService();

                    result.SmaResult = sma.CalculateResult(consumptionDtos);
                    break;

                case PredictionMode.LINEARREGRESSION:
                    var linearRegression = new LinearRegressionService();

                    result.LinearRegressionResult = linearRegression.CalculateResult(consumptionDtos);
                    break;
                case PredictionMode.PERCENTAGEVARIATION:
                    var percentageVariation = new PercentageVariationService();

                    result.PercentageVariationResult = percentageVariation.CalculateResult(consumptionDtos);
                    break;
                case PredictionMode.TRENDDETECTION:
                    var trendDetection = new TrendDetectionService();

                    result.TrendDetectionResult = trendDetection.CalculateResult(consumptionDtos);
                    break;
            }

            vm.PredictionResult = result;

            ViewBag.Modo = currentMode.ToString();
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult SavePredictionMode(PredictionModeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Modos", vm);
            }

            // Update the current prediction mode
            PredictionModeRepository.Instance.CurrentMode = vm.SelectedMode;

            return View("Modos", vm);
        }
    }
}
