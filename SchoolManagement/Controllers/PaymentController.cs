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
        private readonly BootcampDBContext _context;

        private readonly IMapper _mapper;

        public PaymentController(BootcampDBContext context,
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

            var checkPreviousPayments = await _context.Payments.Where(x => x.EnrollmentId == dto.EnrollmentId).ToListAsync();

            decimal currentAmountPayed = 0;
            if (checkPreviousPayments != null && checkPreviousPayments.Count > 0)
            {
                foreach (var previousPayment in checkPreviousPayments)
                {
                    currentAmountPayed += previousPayment.Amount;
                }
            }
            
            var checkCoursePrice = await _context.Enrollments.Include(x => x.Course).FirstOrDefaultAsync(x => x.Id == dto.EnrollmentId);
            if (checkCoursePrice != null)
            {
                var actualCoursePrice = checkCoursePrice.Course.Price;
                if (currentAmountPayed >= actualCoursePrice)
                {
                    throw new Exception($"Student with EnrollmentId { dto.EnrollmentId } has already payed full price for this course!");
                }

                decimal nextPaymentFullAmount = currentAmountPayed + dto.Amount;
                if (nextPaymentFullAmount > actualCoursePrice)
                {
                    //var extraMoneyPayed = nextPaymentFullAmount - actualCoursePrice;
                    var monayToPayForCourse = actualCoursePrice - currentAmountPayed;
                    throw new Exception($"You need to pay only { monayToPayForCourse }$ to fully cover Course price!");
                }
            }
           
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Payments.ToListAsync());
        }
    }

}
