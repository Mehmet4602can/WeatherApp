// Data Katmanı - WeatherDataService.cs

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherDataService
    {
        private readonly HttpClient _httpClient;

        // Constructor'da HttpClient'ı alıyoruz
        public WeatherDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Konum alıp hava durumu verisini alıyoruz
        public async Task<WeatherData> GetWeatherDataAsync(double latitude, double longitude)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://www.7timer.info/bin/api.pl?lon={longitude}&lat={latitude}&product=meteo&output=json");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API isteği başarısız oldu: {response.StatusCode}");
                }

                var responseString = await response.Content.ReadAsStringAsync();
                var weatherData = JsonSerializer.Deserialize<WeatherData>(responseString);

                if (weatherData == null)
                {
                    throw new Exception("Veri deseralize edilemedi.");
                }

                return weatherData;
            }
            catch (Exception ex)
            {
                // Hata mesajını konsola yazdırıyoruz
                Console.WriteLine($"Hata: {ex.Message}");
                return null; // Hata durumunda null dönebiliriz
            }
        }
    }
}