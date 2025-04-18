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
        public WatherData Data { get; set; }
        public string message { get; set; }
        public bool Success { get; set; }
    }
}
