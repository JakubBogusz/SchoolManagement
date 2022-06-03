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
    public class GradeController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public GradeController(BootcampDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grade>>> Get()
        {
            return Ok(await _context.Grades
                .Include(x => x.Subject)
                .Include(x => x.Enrollment)
                    .ThenInclude(x => x.Student)
                    .ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> Get(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return BadRequest("Grade not found.");
            return Ok(grade);
        }

        [HttpPost]
        public async Task<ActionResult<List<Grade>>> AddGrade(GradeDto dto)
        {
            var grade = _mapper.Map<GradeDto, Grade>(dto);

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grades.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Grade>>> UpdateGrade(GradeDto request)
        {
            var dbGrade = await _context.Grades.FindAsync(request.Id);
            if (dbGrade == null)
                return BadRequest("Score not found in database.");

            dbGrade.GradeValue = request.GradeValue;
            dbGrade.SubjectId = request.SubjectId;
            dbGrade.EnrollmentId = request.EnrollmentId;
            dbGrade.Percent = request.Percent;
            dbGrade.Date = request.Date;

            await _context.SaveChangesAsync();

            return Ok(await _context.Grades.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Grade>>> Delete(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return BadRequest("Grade not found in database.");

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return Ok(await _context.Grades.ToListAsync());
        }
    }
}
