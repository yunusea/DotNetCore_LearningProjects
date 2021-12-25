using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            int a = 0;
            int b = 10 / a;

            return "OK";
        }
    }
}
