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
        private readonly IPostRepository _postRepository;

        public EmployeesController(IEmployeesRepository employeesRepository,IPostRepository postRepository, IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
            _postRepository = postRepository;
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployees([FromQuery] int id_employees, [FromQuery] int id_post, [FromBody] EmployeesDto employees_create)
        {
            if (employees_create == null)
                return BadRequest(ModelState);

            var employees = _employeesRepository.GetEmployeesCollection()
                .Where(c => c.surname.ToString().Trim().ToUpper() == employees_create.surname.ToString().TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employees != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeesMap = _mapper.Map<Employees>(employees_create);

            employeesMap.Post = _postRepository.GetPostId(id_post);


            if (!_employeesRepository.CreateEmployees(employeesMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_employees}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployees(int id_employees, [FromBody] EmployeesDto employees_update)
        {
            if (employees_update == null)
                return BadRequest(ModelState);

            if (id_employees != employees_update.id_employess)
                return BadRequest(ModelState);

            if (!_employeesRepository.EmployeesExists(id_employees))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var EmployeesMap = _mapper.Map<Employees>(employees_update);

            if (!_employeesRepository.UpdateEmployees(EmployeesMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_employees}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployees(int id_employees)
        {
            if (!_employeesRepository.EmployeesExists(id_employees))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Employees = _employeesRepository.GetEmployeesId(id_employees);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_employeesRepository.DeleteEmployees(Delete_Employees))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
