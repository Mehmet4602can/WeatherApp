using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherApp.Entity.RequestAPİ
{
    public class WatherData
    {
        public string name {  get; set; }
        public Main Main { get; set; }
        public List<Wather> Wather { get; set; }
        public Wind Wind { get; set; }
    }
}
