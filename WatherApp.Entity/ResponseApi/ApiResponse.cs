using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatherApp.Entity.RequestAPİ;

namespace WatherApp.Entity.ResponseApi
{
    public class ApiResponse
    {
        public WeatherData Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
