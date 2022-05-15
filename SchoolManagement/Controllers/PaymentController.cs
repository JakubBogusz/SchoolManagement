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
    public class PaymentController : ControllerBase
    {
        private readonly SchoolManagementDBContext _context;

        private readonly IMapper _mapper;

        public PaymentController(SchoolManagementDBContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> Get()
        {
            return Ok(await _context.Payments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> Get(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return BadRequest("Payment not found.");
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Payment>>> AddPayment(PaymentDto dto)
        {
            var payment = _mapper.Map<PaymentDto, Payment>(dto);

            var alreadyPayed = _context.Payments.Any(pay => pay.StudentId == payment.StudentId && pay.CourseId == payment.CourseId);
            if (!alreadyPayed)
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
            }
            else
            {
                new Exception("Student already payed for this course!");
            }

            return Ok(await _context.Payments.ToListAsync());
        }
    }

}
