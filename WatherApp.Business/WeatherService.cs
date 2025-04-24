using Newtonsoft.Json;
using WatherApp.Entity.RequestAPİ;
using WatherApp.Entity.ResponseApi;

namespace WatherApp.Business
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse> GetWeatherDataAsync(OpenWeatherRequest request)
        {
            var url = $"{_baseUrl}?q={request.City}&appid={request.ApiKey}&units={request.Units}&lang={request.Language}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) { /* logla vs. */ }
                var json = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                return new ApiResponse
                {
                    Data = weatherData,
                    Success = true,
                    Message = "Başarıyla Alındı!"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Message = "Hata Oluştu!\n" + ex.Message,
                    Success = false,
                };
            }
        }
    }
}
