using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            //try
            //{
            //    throw new Exception("Test Hatası");

            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}


            //Burada bir exception oluşacak ve middleware içerisinde ki catch bloğuna düşecek otomatik olarak.
            throw new Exception("Test Hatası");

            return "Ok";
        }
    }
}
