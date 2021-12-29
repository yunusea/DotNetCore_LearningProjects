using AutoMapper;
using BestPractices.API.Data.Models;
using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.API.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public MemberService(IMapper Mapper, IHttpClientFactory HttpClientFactory)
        {
            mapper = Mapper;
            httpClientFactory = HttpClientFactory;
        }

        public MemberDVO GetMemberById(int Id)
        {
            Member m = GetDummyMember();

            var client = httpClientFactory.CreateClient("fongogoapi");

            //Using Automapper
            MemberDVO resultMember = mapper.Map<MemberDVO>(m);
            return resultMember;

            //Before using AutoMapper
            //return new MemberDVO()
            //{
            //    Id = m.Id,
            //    FullName = $"{m.FirstName} {m.LastName}"
            //};
        }

        private Member GetDummyMember()
        {
            return new Member()
            {
                Id = 1,
                FirstName = "Yunus Emre",
                LastName = "AKBULUT"
            };
        }
    }
}
