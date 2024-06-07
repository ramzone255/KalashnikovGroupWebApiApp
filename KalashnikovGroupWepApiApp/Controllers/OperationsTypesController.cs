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
    }
}
