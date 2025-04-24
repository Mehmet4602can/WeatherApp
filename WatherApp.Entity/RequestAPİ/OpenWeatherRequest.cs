using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherApp.Entity.RequestAPİ
{
    public class OpenWeatherRequest
    {
        public string City { get; set; }
        public string ApiKey { get; set; }
        public string Units { get; set; }
        public string Language { get; set; }
    }
}
