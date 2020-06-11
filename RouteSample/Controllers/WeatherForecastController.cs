using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RouteSample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                             {
                                 Date = DateTime.Now.AddDays(index),
                                 TemperatureC = rng.Next(-20, 55),
                                 Summary = Summaries[rng.Next(Summaries.Length)]
                             })
                             .ToArray();
        }

        [Route("{id:int}")]
        [HttpGet]
        public int Value(int id)
        {
            return id;
        }

        [Route("{id:max(10)}")]
        [HttpGet]
        public int Value2(int id)
        {
            return id;
        }

        [Route("{id:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}")]
        [HttpGet]
        public string Value3(string id)
        {
            return id;
        }

        [Route("{name:required}")]
        [HttpGet]
        public string Value4(string name)
        {
            return name;
        }

        [Route("{*name}")]
        [HttpGet]
        public string Value5(string name)
        {
            return name;
        }

        [Route("{name:MyRouteConstraint}")]
        [HttpGet]
        public string Value6(string name)
        {
            return name;
        }
    }
}