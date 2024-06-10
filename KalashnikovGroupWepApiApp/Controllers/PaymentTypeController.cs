using AutoMapper;
using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository;
using KalashnikovGroupWepApiApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KalashnikovGroupWepApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeRepository _paymenttypeRepository;
        private readonly IMapper _mapper;

        public PaymentTypeController(IPaymentTypeRepository paymenttypeRepository, IMapper mapper)
        {
            _paymenttypeRepository = paymenttypeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentType>))]

        public IActionResult GetPaymentType()
        {
            var PaymentType = _mapper.Map<List<PaymentTypeDto>>(_paymenttypeRepository.GetPaymentTypeCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(PaymentType);

        }
        [HttpGet("{paymenttype_id}")]
        [ProducesResponseType(200, Type = typeof(PaymentType))]
        [ProducesResponseType(400)]
        public IActionResult GetPaymentType_pt(int paymenttype_id)
        {
            if (!_paymenttypeRepository.PaymentTypeExists(paymenttype_id))
                return BadRequest(new { message = "Error: Invalid Id" });

            var PaymentType = _mapper.Map<PaymentTypeDto>(_paymenttypeRepository.GetPaymentTypeId(paymenttype_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(PaymentType);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePaymentType([FromBody] PaymentTypeDto paymenttype_create)
        {
            if (paymenttype_create == null)
                return BadRequest(ModelState);

            var paymenttype = _paymenttypeRepository.GetPaymentTypeCollection()
                .Where(c => c.denomination.Trim().ToUpper() == paymenttype_create.denomination.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (paymenttype != null)
            {
                ModelState.AddModelError("", "Component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymenttypeMap = _mapper.Map<PaymentType>(paymenttype_create);

            if (!_paymenttypeRepository.CreatePaymentType(paymenttypeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{paymenttype_id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePaymentType(int paymenttype_id, [FromBody] PaymentTypeDto paymenttype_update)
        {
            if (paymenttype_update == null)
                return BadRequest(ModelState);

            if (paymenttype_id != paymenttype_update.id_payments_type)
                return BadRequest(ModelState);

            if (!_paymenttypeRepository.PaymentTypeExists(paymenttype_id))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var PaymentTypeMap = _mapper.Map<PaymentType>(paymenttype_update);

            if (!_paymenttypeRepository.UpdatePaymentType(PaymentTypeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{paymenttype_id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePaymentType(int paymenttype_id)
        {
            if (!_paymenttypeRepository.PaymentTypeExists(paymenttype_id))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_PaymentType = _paymenttypeRepository.GetPaymentTypeId(paymenttype_id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymenttypeRepository.DeletePaymentType(Delete_PaymentType))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
    

}
