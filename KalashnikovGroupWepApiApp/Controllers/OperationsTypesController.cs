using AutoMapper;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository;
using KalashnikovGroupWepApiApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace KalashnikovGroupWepApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsTypesController : Controller
    {
        private readonly IOperationsTypesRepository _operationstypesRepository;
        private readonly IMapper _mapper;

        public OperationsTypesController(IOperationsTypesRepository operationstypesRepository, IMapper mapper)
        {
            _operationstypesRepository = operationstypesRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OperationsTypes>))]
        public IActionResult GetOperationsTypes()
        {
            var OperationsTypes = _mapper.Map<List<OperationsTypesDto>>(_operationstypesRepository.GetOperationsTypesCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(OperationsTypes);
        }
        [HttpGet("{op_id}")]
        [ProducesResponseType(200, Type = typeof(OperationsTypes))]
        [ProducesResponseType(400)]
        public IActionResult GetOperationsTypes_op(int op_id)
        {
            if (!_operationstypesRepository.OperationsTypesExists(op_id))
                return BadRequest(new { message = "Error: Invalid Id" });

            var OperationsTypes = _mapper.Map<OperationsTypesDto>(_operationstypesRepository.GetOperationsTypesId(op_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(OperationsTypes);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOperationsTypes([FromBody] OperationsTypesDto operationstypes_create)
        {
            if (operationstypes_create == null)
                return BadRequest(ModelState);

            var operationstypes = _operationstypesRepository.GetOperationsTypesCollection()
                .Where(c => c.denomination.Trim().ToUpper() == operationstypes_create.denomination.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (operationstypes != null)
            {
                ModelState.AddModelError("", "Component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var operationstypesMap = _mapper.Map<OperationsTypes>(operationstypes_create);

            if (!_operationstypesRepository.CreateOperationsTypes(operationstypesMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_operations_types}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOperationsTypes(int id_operations_types, [FromBody] OperationsTypesDto operationstypes_update)
        {
            if (operationstypes_update == null)
                return BadRequest(ModelState);

            if (id_operations_types != operationstypes_update.operations_types)
                return BadRequest(ModelState);

            if (!_operationstypesRepository.OperationsTypesExists(id_operations_types))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var OperationsTypesMap = _mapper.Map<OperationsTypes>(operationstypes_update);

            if (!_operationstypesRepository.UpdateOperationsTypes(OperationsTypesMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_operations_types}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOperationsTypes(int id_operations_types)
        {
            if (!_operationstypesRepository.OperationsTypesExists(id_operations_types))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_OperationsTypes = _operationstypesRepository.GetOperationsTypesId(id_operations_types);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_operationstypesRepository.DeleteOperationsTypes(Delete_OperationsTypes))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
