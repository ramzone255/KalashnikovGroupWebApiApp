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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePayday([FromBody] PaydayDto payday_create)
        {
            if (payday_create == null)
                return BadRequest(ModelState);

            var payday = _paydayRepository.GetPaydayCollection()
                .Where(c => c.paycheck.ToString().Trim().ToUpper() == payday_create.paycheck.ToString().TrimEnd().ToUpper())
                .FirstOrDefault();

            if (payday != null)
            {
                ModelState.AddModelError("", "Component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paydayMap = _mapper.Map<Payday>(payday_create);

            if (!_paydayRepository.CreatePayday(paydayMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_payday}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePayday(int id_payday, [FromBody] PaydayDto payday_update)
        {
            if (payday_update == null)
                return BadRequest(ModelState);

            if (id_payday != payday_update.id_payday)
                return BadRequest(ModelState);

            if (!_paydayRepository.PaydayExists(id_payday))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var PaydayMap = _mapper.Map<Payday>(payday_update);

            if (!_paydayRepository.UpdatePayday(PaydayMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_payday}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayday(int id_payday)
        {
            if (!_paydayRepository.PaydayExists(id_payday))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Payday = _paydayRepository.GetPaydayId(id_payday);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paydayRepository.DeletePayday(Delete_Payday))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
