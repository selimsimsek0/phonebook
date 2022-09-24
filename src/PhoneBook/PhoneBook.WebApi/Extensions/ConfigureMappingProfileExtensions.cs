using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Entity.DTO;
using PhoneBook.Entity.Entity;
using System;

namespace PhoneBook.WebApi.Extensions
{
    public static class ConfigureMappingProfileExtensions
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(p => p.AddProfile(new AutoMapperMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }

        public class AutoMapperMappingProfile:Profile
        {
            public AutoMapperMappingProfile()
            {
                CreateMap<AddPersonDTO, Person>()
                    .ForMember(p => p.Id, y => y.MapFrom(con => Guid.Empty))
                    .ForMember(p => p.CreationDate, y => y.MapFrom(con => DateTime.Now));

                CreateMap<AddContactInfoDTO, ContactInfo>()
                   .ForMember(p => p.Id, y => y.MapFrom(con => Guid.Empty))
                   .ForMember(p => p.CreationDate, y => y.MapFrom(con => DateTime.Now));

            }
        }
    }
}
