using AutoMapper;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository;
using KalashnikovGroupWepApiApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KalashnikovGroupWepApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymenttypeRepository;

        public PaymentsController(IPaymentsRepository paymentsRepository, IMapper mapper, IPaymentTypeRepository paymenttypeRepository)
        {
            _paymentsRepository = paymentsRepository;
            _mapper = mapper;
            _paymenttypeRepository = paymenttypeRepository;

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payments>))]
        public IActionResult GetPayments()
        {
            var Payments = _mapper.Map<List<PaymentsDto>>(_paymentsRepository.GetPaymentsCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Payments);

        }
        [HttpGet("{id_payments}")]
        [ProducesResponseType(200, Type = typeof(Payments))]
        [ProducesResponseType(400)]
        public IActionResult GetPaymentsId(int id_payments)
        {
            if (!_paymentsRepository.PaymentsExists(id_payments))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Payments = _mapper.Map<PaymentsDto>(_paymentsRepository.GetPaymentsId(id_payments));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Payments);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePayments([FromQuery] int id_payments, [FromQuery] int ptId, [FromBody] PaymentsDto payments_create)
        {
            if (payments_create == null)
                return BadRequest(ModelState);

            var payments = _paymentsRepository.GetPaymentsCollection()
                .Where(c => c.description.Trim().ToUpper() == payments_create.description.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (payments != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentsMap = _mapper.Map<Payments>(payments_create);

            paymentsMap.PaymentType = _paymenttypeRepository.GetPaymentTypeId(ptId);


            if (!_paymentsRepository.CreatePayments(paymentsMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_payments}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePost(int id_payments, [FromBody] PaymentsDto payment_update)
        {
            if (payment_update == null)
                return BadRequest(ModelState);

            if (id_payments != payment_update.id_payments)
                return BadRequest(ModelState);

            if (!_paymentsRepository.PaymentsExists(id_payments))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var PaymentsMap = _mapper.Map<Payments>(payment_update);

            if (!_paymentsRepository.UpdatePayments(PaymentsMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_payments}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayments(int id_payments)
        {
            if (!_paymentsRepository.PaymentsExists(id_payments))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Payments = _paymentsRepository.GetPaymentsId(id_payments);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymentsRepository.DeletePayments(Delete_Payments))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
