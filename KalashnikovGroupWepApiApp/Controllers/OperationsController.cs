using AutoMapper;
using Azure;
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
        private readonly IOperationsTypesRepository _operationstypesRepository;
        private readonly IComponentsRepository _componentsRepository;
        public OperationsController(IOperationsRepository operationsRepository, IMapper mapper, IComponentsRepository componentsRepository, IOperationsTypesRepository operationstypesRepository)
        {
            _operationsRepository = operationsRepository;
            _mapper = mapper;
            _componentsRepository = componentsRepository;
            _operationstypesRepository = operationstypesRepository;
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOperations([FromQuery] int id_operations, [FromQuery] int comId, [FromQuery] int otId, [FromBody] OperationsDto operations_create)
        {
            if (operations_create == null)
                return BadRequest(ModelState);

            var operations = _operationsRepository.GetOperationsCollection()
                .Where(c => c.price.ToString().Trim().ToUpper() == operations_create.price.ToString().TrimEnd().ToUpper())
                .FirstOrDefault();

            if (operations != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var operationsMap = _mapper.Map<Operations>(operations_create);

            operationsMap.OperationsTypes = _operationstypesRepository.GetOperationsTypesId(otId);
            operationsMap.Components = _componentsRepository.GetComponentsId(comId);


            if (!_operationsRepository.CreateOperations(operationsMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_operations}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOperations(int id_operations, [FromBody] OperationsDto operations_update)
        {
            if (operations_update == null)
                return BadRequest(ModelState);

            if (id_operations != operations_update.id_operations)
                return BadRequest(ModelState);

            if (!_operationsRepository.OperationsExists(id_operations))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var OperationsMap = _mapper.Map<Operations>(operations_update);

            if (!_operationsRepository.UpdateOperations(OperationsMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_operations}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOperations(int id_operations)
        {
            if (!_operationsRepository.OperationsExists(id_operations))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Operations = _operationsRepository.GetOperationsId(id_operations);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_operationsRepository.DeleteOperations(Delete_Operations))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
