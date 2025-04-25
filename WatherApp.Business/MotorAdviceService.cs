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
            double temp = data.Main.Temp;
            double wind = data.Wind.Speed;
            double humidity = data.Main.Humidity;
            double visibility = data.Visibility / 1000.0; // KM cinsinden
            string description = data.Weather.FirstOrDefault()?.Description?.ToLower() ?? "";

            bool isRainy = description.Contains("yağmur") || description.Contains("rain");
            bool isSnowy = description.Contains("kar") || description.Contains("snow");
            bool isFoggy = visibility < 2;
            bool isWindy = wind > 10;
            bool isTooCold = temp < 5;
            bool isHot = temp > 30;

            if (isRainy)
                return HandleRainy(isWindy, isTooCold, isFoggy);

            if (isSnowy)
                return isTooCold
                    ? "Kar yağıyor ve ayaz donduruyor. Motor değil kıza bile gidilmez bu havada."
                    : "Kar var ama ayaz yok, yumuşak kar. Ama yine de dikkat et, şaka değil.";

            if (isFoggy)
                return isWindy
                    ? "Sis + rüzgar, bildiğin Silent Hill havası. Motorla değil helikopterle çık."
                    : "Sis var ama rüzgar yok. Farların sağlam ve refleksin hızlıysa dikkatli sür.";

            if (isWindy)
                return isHot
                    ? "Sıcak ama rüzgarla birlikte serin gibi gelir, ama rüzgar dengesiz."
                    : "Rüzgar var, virajlarda dikkat et. Motoru eğme, kendini eğ.";

            if (isTooCold)
                return "Hava kuru ama buz gibi. Kalın giyin, yoksa motordan çok dondurma gibi olursun.";

            if (isHot)
                return "Hava sıcak, asfalt da sıcak. Lastikler yapışır, çık ama bol su iç.";

            return "Hava mis gibi, ne yağmur ne sis ne rüzgar. Çık motorla sucuk gibi gez dayı!";
        }

        private string HandleRainy(bool isWindy, bool isTooCold, bool isFoggy)
        {
            if (isWindy)
                return isTooCold
                    ? "Yağmur + rüzgar + soğuk = cehennemin soğuk versiyonu. Kesinlikle çıkma!"
                    : "Yağmur var ve rüzgar da var hacı, dengeni kaybedersin. Bugün evdesin.";
            else
                return isFoggy
                    ? "Yağmur + sis... Görüş sıfır, ıslaklık %100. Anca kaza olur lan."
                    : "Yağmur var ama rüzgar yok. Yavaş sürersen çıkabilirsin ama dikkatli ol.";
        }
    }
}
