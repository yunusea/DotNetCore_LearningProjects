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
            //throw new Exception("Test Hatası");

            return "Ok";
        }

        [HttpGet("Product")]
        public Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                ProductName = "PC"
            };
        }

        [HttpPost("Product")]
        public string CreateProduct([FromBody]Product product)
        {
            return "Ürün Oluşturuldu !";
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
