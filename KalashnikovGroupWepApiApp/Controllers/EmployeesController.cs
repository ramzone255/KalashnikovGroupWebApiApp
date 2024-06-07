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
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesRepository employeesRepository, IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employees>))]
        public IActionResult GetEmployees()
        {
            var Employees = _mapper.Map<List<EmployeesDto>>(_employeesRepository.GetEmployeesCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Employees);

        }
        [HttpGet("{employees_id}")]
        [ProducesResponseType(200, Type = typeof(Employees))]
        [ProducesResponseType(400)]
        public IActionResult Getemployees_id(int employees_id)
        {
            if (!_employeesRepository.EmployeesExists(employees_id))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Employees = _mapper.Map<EmployeesDto>(_employeesRepository.GetEmployeesId(employees_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Employees);
        }
    }
}
