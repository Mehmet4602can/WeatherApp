using Microsoft.AspNetCore.Mvc;
using WeatherApp.Data;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherDataService _weatherDataService;

        // Dependency Injection ile WeatherDataService'i alýyoruz
        public HomeController(WeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        // Home/index'de konumdan hava durumu verisini alýyoruz
        public async Task<IActionResult> Index(double latitude, double longitude)
        {
            var weatherData = await _weatherDataService.GetWeatherDataAsync(latitude, longitude);

            if (weatherData == null)
            {
                // Hata varsa, kullanýcýya bildirim
                ViewBag.ErrorMessage = "Hava durumu verisi alýnamadý.";
                return View();
            }

            return View(weatherData); // Veriyi View'a aktarýyoruz
        }
    }
}