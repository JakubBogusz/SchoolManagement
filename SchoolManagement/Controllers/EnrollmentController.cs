using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public EnrollmentController(BootcampDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Enrollment>>> Get()
        {
            var result = await _context.Enrollments
                .Include(x => x.Grades)
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Include(x => x.Payments)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> Get(int id)
        {
            var enroll = await _context.Enrollments
                .Include(x => x.Payments)
                .Include(x => x.Course)
                .Include(g => g.Grades)
                    .ThenInclude(p => p.Subject)
                    .SingleOrDefaultAsync(x => x.Id == id);
            if (enroll == null)
                return BadRequest("Enrollment not found.");
            return Ok(enroll);
        }

        [HttpPost]
        public async Task<ActionResult<List<Enrollment>>> EnrollStudent(EnrollmentDto dto)
        {
            var enrollment = _mapper.Map<EnrollmentDto, Enrollment>(dto);

            var isAlreadyEnrolled = _context.Enrollments.Any(enroll => enroll.CourseId == enrollment.CourseId && enroll.StudentId == enrollment.StudentId);
            if (!isAlreadyEnrolled)
            {
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();
            }
            else
            {
                new Exception("Student is already enrolled on this course!");
            }

            return Ok(await _context.Enrollments.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Enrollment>>> Delete(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
                return BadRequest("Course not found in database.");

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Enrollments.ToListAsync());
        }
    }
}
