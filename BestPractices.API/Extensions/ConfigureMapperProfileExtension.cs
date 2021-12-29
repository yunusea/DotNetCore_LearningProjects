using AutoMapper;
using BestPractices.API.Data.Models;
using BestPractices.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.API.Extensions
{
    //Create a AutoMapper Configuration Extension
    public static class ConfigureMapperProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            //Add New Mapping Profile to AutoMapper Configuration
            var MappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = MappingConfig.CreateMapper();

            //Add AutoMapper Mapping to Services
            service.AddSingleton(mapper);

            return service;
        }

    }

    //Adding Mapping Profile for AutoMapper
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Member, MemberDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }
}
