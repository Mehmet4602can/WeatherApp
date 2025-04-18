using WeatherApp.Data;
namespace WeatherApp.Business
{
    public class SucukAIService
    {
        private readonly WeatherDataService _weatherDataService;

        public SucukAIService(WeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        public async Task<WeatherAnalysisResult> AnalyzeWeatherAsync(double latitude, double longitude)
        {
            // WeatherDataService'den veri alıyoruz
            var data = await _weatherDataService.GetWeatherDataAsync(latitude, longitude);

            var result = new WeatherAnalysisResult();
            result.TotalScore = CalculateScore(data);
            result.Comments = GenerateComments(data, result.TotalScore);
            return result;
        }

        private int CalculateScore(WeatherData data)
        {
            int score = 0;

            // Hava durumu kuralları
            if (data.Temp < 10 || data.Temp > 30) score -= 20;  // Sıcaklık çok düşük ya da çok yüksekse
            if (data.WindSpeed > 10) score -= 15;  // Rüzgar hızı yüksekse
            score += (100 - data.Humidity) / 10;  // Nem oranı arttıkça pozitif etkisi var

            return score;
        }

        private List<string> GenerateComments(WeatherData data, int score)
        {
            var comments = new List<string>();

            // Yorumlar için esnek bir sistem
            if (score < 20)
                comments.Add("Bugün dışarı çıkmaman iyi olur, hava çok kötü.");
            else if (score >= 20 && score < 40)
                comments.Add("Bugün dışarı çıkabilirsin ama dikkatli ol.");
            else if (score >= 40 && score < 60)
                comments.Add("Hava idare eder, dışarı çıkabilirsin.");
            else if (score >= 60 && score < 80)
                comments.Add("Hava güzel, dışarı çıkabilirsin!");
            else
                comments.Add("Bugün harika bir hava var, dışarı çıkmak için mükemmel bir gün!");

            return comments;
        }
    }
}

