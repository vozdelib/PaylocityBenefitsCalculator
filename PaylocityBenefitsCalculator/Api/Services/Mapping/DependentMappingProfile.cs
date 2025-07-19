using Api.Dtos.Dependent;
using Api.Models;
using AutoMapper;

namespace Api.Services.Mapping
{
    public class DependentMappingProfile : Profile
    {
        public DependentMappingProfile()
        {
            CreateMap<Dependent, GetDependentDto>();
        }
    }
}
