using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WatherApp.Business;
using WatherApp.Entity.RequestAPÝ;
using WatherApp.Models;

namespace WatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MotorAdviceService _motorAdvice;
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherService _weatherService;
        public HomeController(ILogger<HomeController> logger, WeatherService weatherService, MotorAdviceService motorAdvice)
        {
            _logger = logger;
            _weatherService = weatherService;
            _motorAdvice = motorAdvice;
        }

        public async Task<IActionResult> Index()
        {
            var request = new OpenWeatherRequest
            {
                City = "Istanbul",
                ApiKey = "521e88579d6daa2e9424d791a334c6f6",
                Units = "metric",
                Language = "tr",
            };
            var response = await _weatherService.GetWeatherDataAsync(request);
            if(response.Success)
            {
                var advice = _motorAdvice.GetAdvice(response.Data);
                ViewBag.Advice = advice;
                return View(response.Data);
            }
            else
            {
                ViewBag.ErrorMessage = response.Message;
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
