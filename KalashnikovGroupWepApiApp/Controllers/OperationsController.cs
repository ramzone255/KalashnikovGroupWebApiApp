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
    public class OperationsController : Controller
    {
        private readonly IOperationsRepository _operationsRepository;
        private readonly IMapper _mapper;
        public OperationsController(IOperationsRepository operationsRepository, IMapper mapper)
        {
            _operationsRepository = operationsRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Operations>))]
        public IActionResult GetOperations()
        {
            var Operations = _mapper.Map<List<OperationsDto>>(_operationsRepository.GetOperationsCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Operations);

        }
        [HttpGet("{id_operations}")]
        [ProducesResponseType(200, Type = typeof(Operations))]
        [ProducesResponseType(400)]
        public IActionResult GetOperationsId(int id_operations)
        {
            if (!_operationsRepository.OperationsExists(id_operations))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Operations = _mapper.Map<OperationsDto>(_operationsRepository.GetOperationsId(id_operations));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Operations);
        }
    }
}
