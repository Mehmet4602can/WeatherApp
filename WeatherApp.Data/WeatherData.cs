namespace WeatherApp.Data
{
    public class WeatherData
    {
        public int Temp { get; set; }
        public string Condition { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }
        // API'ye göre buraya başka alanlar da ekleyebilirsin.
    }
}