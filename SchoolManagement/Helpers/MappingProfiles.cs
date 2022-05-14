using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentRequestDto>().ReverseMap();

            CreateMap<Lecturer, LecturerDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();

        }
    }
}
