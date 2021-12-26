﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public MemberController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        [HttpGet]
        public string GetSettings()
        {
            //When ASPNETCORE_ENVIRONMENT variable in LaunchSettings is changed, different application settings file is read
            return configuration["ReadMe"].ToString();
        }

    }
}