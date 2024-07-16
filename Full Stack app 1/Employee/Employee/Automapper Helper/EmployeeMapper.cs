using AutoMapper;
using Hospital.Models;
using Hospital.Models.DTOs;
namespace Hospital.Automapper_Helper
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
