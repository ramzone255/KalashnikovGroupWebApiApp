using AutoMapper;
using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository;
using KalashnikovGroupWepApiApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace KalashnikovGroupWepApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaydayController : Controller
    {
        private readonly IPaydayRepository _paydayRepository;
        private readonly IMapper _mapper;
        public PaydayController(IPaydayRepository paydayRepository, IMapper mapper)
        {
            _paydayRepository = paydayRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payday>))]
        public IActionResult GetPayday()
        {
            var Payday = _mapper.Map<List<PaydayDto>>(_paydayRepository.GetPaydayCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Payday);

        }
        [HttpGet("{id_payday}")]
        [ProducesResponseType(200, Type = typeof(Payday))]
        [ProducesResponseType(400)]
        public IActionResult GetPaydayId(int id_payday)
        {
            if (!_paydayRepository.PaydayExists(id_payday))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Payday = _mapper.Map<PaydayDto>(_paydayRepository.GetPaydayId(id_payday));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Payday);
        }
    }
}
