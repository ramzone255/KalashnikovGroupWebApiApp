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
    public class DealController : Controller
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;
        private readonly IOperationsRepository _operationsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        public DealController(IDealRepository dealRepository, IMapper mapper, IOperationsRepository operationsRepository, IEmployeesRepository employeesRepository)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
            _operationsRepository = operationsRepository;
            _employeesRepository = employeesRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Deal>))]
        public IActionResult GetDeal()
        {
            var Deal = _mapper.Map<List<DealDto>>(_dealRepository.GetDealCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Deal);

        }
        [HttpGet("{id_deal}")]
        [ProducesResponseType(200, Type = typeof(Deal))]
        [ProducesResponseType(400)]
        public IActionResult GetDealId(int id_deal)
        {
            if (!_dealRepository.DealExists(id_deal))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Deal = _mapper.Map<DealDto>(_dealRepository.GetDealId(id_deal));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Deal);
        }
        [HttpPost("POST")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDeal([FromQuery] int id_deal, [FromQuery] int id_employees, [FromQuery] int id_operations, [FromBody] DealDto deal_create)
        {
            if (deal_create == null)
                return BadRequest(ModelState);

            var deal = _dealRepository.GetDealCollection()
                .Where(c => c.total_amount.ToString().Trim().ToUpper() == deal_create.total_amount.ToString().TrimEnd().ToUpper())
                .FirstOrDefault();

            if (deal != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dealMap = _mapper.Map<Deal>(deal_create);

            dealMap.Employees = _employeesRepository.GetEmployeesId(id_employees);
            dealMap.Operations = _operationsRepository.GetOperationsId(id_operations);


            if (!_dealRepository.CreateDeal(dealMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("PUT/{id_deal}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDeal(int id_deal, [FromBody] DealDto deal_update)
        {
            if (deal_update == null)
                return BadRequest(ModelState);

            if (id_deal != deal_update.id_deal)
                return BadRequest(ModelState);

            if (!_dealRepository.DealExists(id_deal))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var DealMap = _mapper.Map<Deal>(deal_update);

            if (!_dealRepository.UpdateDeal(DealMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DELETE/{id_deal}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDeal(int id_deal)
        {
            if (!_dealRepository.DealExists(id_deal))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Deal = _dealRepository.GetDealId(id_deal);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_dealRepository.DeleteDeal(Delete_Deal))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
