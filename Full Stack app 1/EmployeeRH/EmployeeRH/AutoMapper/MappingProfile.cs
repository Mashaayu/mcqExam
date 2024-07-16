using AutoMapper;
using EmployeeRH.Models;
using EmployeeRH.Models.DTOs;
namespace EmployeeRH.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<RH, RHDTO>();
            CreateMap<RH,RhDisplayDTO>();
        }
    }
}
