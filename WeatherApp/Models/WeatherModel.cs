using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string CurrentTemperature { get; set; }
        public string HighTemperature { get; set; }
        public string LowTemperature { get; set; }
        public string Weather { get; set; }
        public string WindSpeed { get; set; }
        public string Station { get; set; }
    }
}
