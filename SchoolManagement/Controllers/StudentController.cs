using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Dtos;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolManagementDBContext _context;

        private readonly IGenericRepository<Student> _studentsRepo;

        private readonly IMapper _mapper;

        public StudentController(SchoolManagementDBContext context,
            IGenericRepository<Student> studentsRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _studentsRepo = studentsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            return Ok(await _studentsRepo.ListAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentsRepo.GetByIdAsync(id);
            if (student == null)
                return BadRequest("Student not found.");
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<StudentDto, Student>(studentDto);
            _studentsRepo.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateHero(Student request)
        {
            var dbStudent = await _context.Students.FindAsync(request.Id);
            if (dbStudent == null)
                return BadRequest("dbStudent not found in database.");

            dbStudent.FirstName = request.FirstName;
            dbStudent.LastName = request.LastName;
            dbStudent.EnrollmentDate = request.EnrollmentDate;
 

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
                return BadRequest("Hero not found in database.");

            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}
