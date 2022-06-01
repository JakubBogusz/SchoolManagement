using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Student, StudentRequestDto>().ReverseMap();

            CreateMap<Lecturer, LecturerDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();

            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();

            CreateMap<Grade, GradeDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();

            CreateMap<FinalScore, FinalScoreDto>().ReverseMap();
        }
    }
}
