using Api.Dtos.Employee;
using Api.Models;
using AutoMapper;

namespace Api.Services.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, GetEmployeeDto>().ForMember(
                    dest => dest.Dependents,
                    opt => opt.MapFrom(src => src.Dependents)
                );
        }
    }
}
