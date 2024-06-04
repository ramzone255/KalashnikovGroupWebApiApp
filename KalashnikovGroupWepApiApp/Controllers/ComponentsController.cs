using AutoMapper;
using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Dto;
using KalashnikovGroupWepApiApp.Interface;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository;
using Microsoft.AspNetCore.Mvc;

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
            var Components = _mapper.Map<List<ComponentsDto>>(_componentsRepository.GetComponents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Components);

        }

        [HttpGet("{comp_id}")]
        [ProducesResponseType(200, Type = typeof(Components))]
        [ProducesResponseType(400)]
        public IActionResult GetComponents_comp(int comp_id)
        {
            if (!_componentsRepository.ComponentsExists(comp_id))
                return NotFound();

            var Components = _mapper.Map<ComponentsDto>(_componentsRepository.GetComponents(comp_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Components);
        }
    }
}
