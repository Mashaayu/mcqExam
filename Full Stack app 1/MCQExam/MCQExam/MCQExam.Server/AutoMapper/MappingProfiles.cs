using AutoMapper;
using MCQExam.Server.Models;
using MCQExam.Server.Models.DTOs;

namespace MCQExam.Server.AutoMapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<Instructor, InstructorDTO>();
        }
    }
}
