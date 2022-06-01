using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class FinalScoreController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public FinalScoreController(BootcampDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FinalScore>>> Get()
        {
            return Ok(await _context.FinalScores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinalScore>> Get(int id)
        {
            var score = await _context.FinalScores.FindAsync(id);
            if (score == null)
                return BadRequest("Score not found.");
            return Ok(score);
        }

        [HttpPost]
        public async Task<ActionResult<List<FinalScore>>> AddCourse(FinalScoreDto dto)
        {
            var score = _mapper.Map<FinalScoreDto, FinalScore>(dto);
            _context.FinalScores.Add(score);
            await _context.SaveChangesAsync();

            return Ok(await _context.FinalScores.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<FinalScore>>> UpdateCourse(FinalScoreDto request)
        {
            var dbScore = await _context.FinalScores.FindAsync(request.Id);
            if (dbScore == null)
                return BadRequest("Score not found in database.");

            dbScore.Average = request.Average;
            dbScore.LastUpdatedOn = request.LastUpdatedOn;

            await _context.SaveChangesAsync();

            return Ok(await _context.FinalScores.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FinalScore>>> Delete(int id)
        {
            var scores = await _context.FinalScores.FindAsync(id);
            if (scores == null)
                return BadRequest("Score not found in database.");

            _context.FinalScores.Remove(scores);
            await _context.SaveChangesAsync();

            return Ok(await _context.FinalScores.ToListAsync());
        }
    }
}
