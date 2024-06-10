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
        public DealController(IDealRepository dealRepository, IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
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
    }
}
