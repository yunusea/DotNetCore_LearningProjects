using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRandomValueGenerator randomValueGenerator;

        public TestController(IRandomValueGenerator RandomValueGenerator)
        {
            randomValueGenerator = RandomValueGenerator;
        }

        [HttpGet]
        public string Get()
        {
            //RandomValueGenerator n = new RandomValueGenerator();
            //int number = n.RandomValue;

            //return number.ToString();
            return randomValueGenerator.RandomValue.ToString();
        }
    }
}
