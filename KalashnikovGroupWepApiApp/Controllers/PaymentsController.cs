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

        public PaymentsController(IPaymentsRepository paymentsRepository, IMapper mapper)
        {
            _paymentsRepository = paymentsRepository;
            _mapper = mapper;
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
    }
}
