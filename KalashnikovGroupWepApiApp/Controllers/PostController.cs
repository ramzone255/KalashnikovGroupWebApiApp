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

        public IActionResult GetPostCollection()
        {
            var Post = _mapper.Map<List<PostDto>>(_postRepository.GetPostCollection());

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
                return BadRequest(new {message = "Error: Invalid Id" } );

            var Post = _mapper.Map<PostDto>(_postRepository.GetPostId(ps_id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Post);
        }
    }
}
