﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Context;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolManagementDBContext _context;

        private readonly IMapper _mapper;

        public CourseController(SchoolManagementDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> Get()
        {
            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course= await _context.Courses.FindAsync(id);
            if (course == null)
                return BadRequest("Hero not found.");
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<List<Course>>> AddCourse(CourseDto dto)
        {
            var course = _mapper.Map<CourseDto, Course>(dto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Course>>> UpdateCourse(CourseDto request)
        {
            var dbCourse = await _context.Courses.FindAsync(request.Id);
            if (dbCourse == null)
                return BadRequest("Course not found in database.");

            dbCourse.CourseName = request.CourseName;
            dbCourse.CourseDescription = request.CourseDescription;
            dbCourse.Price = request.Price;
            dbCourse.Level = request.Level;
            dbCourse.Code = request.Code;
            dbCourse.StartDate = request.StartDate;
            dbCourse.EndDate = request.EndDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> Delete(int id)
        {
            var Course = await _context.Courses.FindAsync(id);
            if (Course == null)
                return BadRequest("Course not found in database.");

            _context.Courses.Remove(Course);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}