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
        [HttpGet("{pt_id}")]
        [ProducesResponseType(200, Type = typeof(PaymentType))]
        [ProducesResponseType(400)]
        public IActionResult GetPaymentType_pt(int pt_id)
        {
            if (!_paymenttypeRepository.PaymentTypeExists(pt_id))
                return BadRequest(new { message = "Error: Invalid Id" });

            var PaymentType = _mapper.Map<PaymentTypeDto>(_paymenttypeRepository.GetPaymentTypeId(pt_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(PaymentType);
        }
    }
    

}
