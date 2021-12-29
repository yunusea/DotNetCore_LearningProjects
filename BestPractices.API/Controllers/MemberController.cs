using BestPractices.API.Models;
using BestPractices.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMemberService memberService;

        public MemberController(IConfiguration Configuration, IMemberService MemberService)
        {
            configuration = Configuration;
            memberService = MemberService;
        }

        [HttpGet]
        public string GetSettings()
        {
            //When ASPNETCORE_ENVIRONMENT variable in LaunchSettings is changed, different application settings file is read
            return configuration["ReadMe"].ToString();
        }

        [ResponseCache(Duration = 10)] //This Attribute for 10 Second caching
        [HttpGet("Id")]
        public MemberDVO GetMemberById(int Id)
        {
            return memberService.GetMemberById(Id);
        }

        [HttpPost]
        public MemberDVO CreateMember(MemberDVO Member)
        {
            return Member;
        }

    }
}
