using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatherApp.Entity.RequestAPİ;

namespace WatherApp.Business
{
    public class MotorAdviceService
    {
        public string GetAdvice(WeatherData data)
        {
            var temp = data.Main.Temp;
            var wind = data.Wind.Speed;
            var description = data.Weather.FirstOrDefault()?.Description?.ToLower() ?? "";

            if (temp < 5)
                return "Lan Memo buz gibi, motor falan hikaye. Çay demle.";
            if (wind > 10)
                return "Rüzgar var hacı, motorla uçarsın, sakin ol.";
            if (description.Contains("yağmur") || description.Contains("snow") || description.Contains("kar"))
                return "Yağmur var lan, sucuğu da kendini de suda haşlama.";
            return "Bugün mis gibi Memo, çıkar motoru, afiyetle gez.";
        }
    }
}
