using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Dtos;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public LecturerController(BootcampDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lecturer>>> Get()
        {
            return Ok(await _context.Lecturers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> Get(int id)
        {
            var lect = await _context.Lecturers.FindAsync(id);
            if (lect == null)
                return BadRequest("Hero not found.");
            return Ok(lect);
        }

        [HttpPost]
        public async Task<ActionResult<List<Lecturer>>> AddLecturer(LecturerDto dto)
        {
            var lect = _mapper.Map<LecturerDto, Lecturer>(dto);
            _context.Lecturers.Add(lect);
            await _context.SaveChangesAsync();

            return Ok(await _context.Lecturers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Lecturer>>> UpdateLecturer(LecturerDto request)
        {
            var dbLecturer = await _context.Lecturers.FindAsync(request.Id);
            if (dbLecturer == null)
                return BadRequest("Lecturer not found in database.");

            dbLecturer.FirstName = request.FirstName;
            dbLecturer.LastName = request.LastName;
            dbLecturer.Title = request.Title;

            await _context.SaveChangesAsync();

            return Ok(await _context.Lecturers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Lecturer>>> Delete(int id)
        {
            var dbLecturer = await _context.Lecturers.FindAsync(id);
            if (dbLecturer == null)
                return BadRequest("Lecturer not found in database.");

            _context.Lecturers.Remove(dbLecturer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}
