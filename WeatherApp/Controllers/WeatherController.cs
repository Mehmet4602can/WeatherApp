using Microsoft.AspNetCore.Mvc;
using WeatherApp.Business;

public class WeatherController : Controller
{
    private readonly SucukAIService _sucukAIService;

    public WeatherController(SucukAIService sucukAIService)
    {
        _sucukAIService = sucukAIService;
    }

    public async Task<IActionResult> Result(double lat, double lon)
    {
        var result = await _sucukAIService.AnalyzeWeatherAsync(lat, lon);
        return View(result);
    }
}