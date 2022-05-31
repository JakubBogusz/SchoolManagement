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
    public class SubjectController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public SubjectController(BootcampDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> Get(int id)
        {
            var item = await _context.Subjects.FindAsync(id);
            if (item == null)
                return BadRequest("Item not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subject>>> AddSubject(SubjectDto dto)
        {
            var subject = _mapper.Map<SubjectDto, Subject>(dto);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subject>>> UpdateSubject(SubjectDto request)
        {
            var item = await _context.Subjects.FindAsync(request.Id);
            if (item == null)
                return BadRequest("Subject not found in database.");

            item.SubjectName = request.SubjectName;
            item.Field = request.Field;
            item.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject>>> Delete(int id)
        {
            var item = await _context.Subjects.FindAsync(id);
            if (item == null)
                return BadRequest("Subject not found in database.");

            _context.Subjects.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }
    }
}
