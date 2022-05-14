using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap()
                ;

        }
    }
}
