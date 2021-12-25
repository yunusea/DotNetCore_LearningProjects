using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLearning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRandomValueGenerator randomValueGenerator;
        private readonly IRandomValueGenerator2 randomValueGenerator2;

        public WeatherForecastController(IRandomValueGenerator RandomValueGenerator, IRandomValueGenerator2 RandomValueGenerator2)
        {
            randomValueGenerator = RandomValueGenerator;
            randomValueGenerator2 = RandomValueGenerator2;
        }

        [HttpGet]
        public string Get()
        {
            int Random1 = randomValueGenerator.RandomValue;
            int Random2 = randomValueGenerator2.RandomValue;

            //int number = numGenerator.RandomValue;

            //NumGenerator n = new NumGenerator();
            //int number = n.GetRandomNumber();

            //n = null;

            return $"RandomValueGenerator.RandomValue: {Random1}, RandomValueGenerator2.RandomValueGenerator.RandomValue: {Random2}";
        }
    }
}
