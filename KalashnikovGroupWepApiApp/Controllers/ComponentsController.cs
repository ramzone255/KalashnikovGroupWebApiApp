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
    public class ComponentsController : Controller
    {
        private readonly IComponentsRepository _componentsRepository;
        private readonly IMapper _mapper;

        public ComponentsController(IComponentsRepository componentsRepository, IMapper mapper)
        {
            _componentsRepository = componentsRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Components>))]
        public IActionResult GetComponents()
        {
            var Components = _mapper.Map<List<ComponentsDto>>(_componentsRepository.GetComponentsCollection());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Components);

        }

        [HttpGet("{id_components}")]
        [ProducesResponseType(200, Type = typeof(Components))]
        [ProducesResponseType(400)]
        public IActionResult GetComponents_comp(int id_components)
        {
            if (!_componentsRepository.ComponentsExists(id_components))
                return BadRequest(new { message = "Error: Invalid Id" });

            var Components = _mapper.Map<ComponentsDto>(_componentsRepository.GetComponentsId(id_components));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Components);
        }
        [HttpPost("POST")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComponents([FromBody] ComponentsDto components_create)
        {
            if (components_create == null)
                return BadRequest(ModelState);

            var components = _componentsRepository.GetComponentsCollection()
                .Where(c => c.denomination.Trim().ToUpper() == components_create.denomination.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (components != null)
            {
                ModelState.AddModelError("", "Component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var componentsMap = _mapper.Map<Components>(components_create);

            if (!_componentsRepository.CreateComponents(componentsMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("PUT/{id_components}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComponents(int id_components, [FromBody] ComponentsDto components_update)
        {
            if (components_update == null)
                return BadRequest(ModelState);

            if (id_components != components_update.id_components)
                return BadRequest(ModelState);

            if (!_componentsRepository.ComponentsExists(id_components))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var ComponentsMap = _mapper.Map<Components>(components_update);

            if (!_componentsRepository.UpdateComponents(ComponentsMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DELETE/{id_components}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteСomponents(int id_components)
        {
            if (!_componentsRepository.ComponentsExists(id_components))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Components = _componentsRepository.GetComponentsId(id_components);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_componentsRepository.DeleteComponents(Delete_Components))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
