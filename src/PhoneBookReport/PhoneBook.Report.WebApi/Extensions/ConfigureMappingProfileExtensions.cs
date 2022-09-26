using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Report.Common;
using PhoneBook.Report.Common.Extensions;
using PhoneBook.Report.Entity.DTO;
using PhoneBook.Report.Entity.Entity;
using System;

namespace PhoneBook.Report.WebApi.Extensions
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

        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                CreateMap<AddLocationReportDTO, LocationReport>()
                    .ForMember(p => p.Id, y => y.MapFrom(con => Guid.Empty))
                    .ForMember(p => p.CreationDate, y => y.MapFrom(con => DateTime.Now));

                CreateMap<AddLocationReportRequestDTO, LocationReportRequest>()
                   .ForMember(p => p.Id, y => y.MapFrom(con => Guid.Empty))
                   .ForMember(p => p.CreationDate, y => y.MapFrom(con => DateTime.Now));

                CreateMap<LocationReport, LocationReportDTO>()
                    .ForMember(p => p.ReportId, y => y.MapFrom(con => con.Id))
                    .ForMember(p => p.Status, y => y.MapFrom(con => con.ReportRequest.Status))
                    .ForMember(p => p.StatusDescription, y => y.MapFrom(con => ((Enums.CreatedStatus)con.ReportRequest.Status).ToDescription()));
            }
        }
    }
}
