using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.External;

namespace WeatherApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Weather")]
    public class WeatherController : Controller
    {
        const string APIKey = "9b94855035c3d31721c13cd6a34ce3c2";

        // GET: api/Weather/30808
        [HttpGet("{zip}", Name = "Get")]
        public WeatherModel Get(string zip)
        {
            WeatherModel model = new WeatherModel();
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?zip={0},us&appid={1}&units=imperial", zip, APIKey);

            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                WeatherResult weatherResult = JsonConvert.DeserializeObject(reader.ReadToEnd(), typeof(WeatherResult)) as WeatherResult;

                model.CurrentTemperature = weatherResult.main.temp.ToString();
                model.LowTemperature = weatherResult.main.temp_min.ToString();
                model.HighTemperature = weatherResult.main.temp_max.ToString();
                model.Weather = weatherResult.weather[0].description;
                model.WindSpeed = weatherResult.wind.speed.ToString();
                model.Station = weatherResult.name;
            }
            catch
            {
                //log actual error internally
                throw new Exception("Unable to retrieve weather data");
            }

            return model;
        }
        
    }
}
