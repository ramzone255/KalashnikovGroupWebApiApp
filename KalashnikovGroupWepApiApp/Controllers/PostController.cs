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
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]

        public IActionResult GetPost()
        {
            var Post = _mapper.Map<List<PostDto>>(_postRepository.GetPost());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Post);

        }
        [HttpGet("{ps_id}")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(400)]
        public IActionResult GetPost_ps(int ps_id)
        {
            if (!_postRepository.PostExists(ps_id))
                return NotFound();

            var Post = _mapper.Map<PostDto>(_postRepository.GetPost(ps_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Post);
        }
    }
}
