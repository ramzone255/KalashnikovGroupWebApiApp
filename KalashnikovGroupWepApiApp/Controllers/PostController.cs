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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePost([FromBody] PostDto post_create)
        {
            if (post_create == null)
                return BadRequest(ModelState);

            var components = _postRepository.GetPostCollection()
                .Where(c => c.denomination.Trim().ToUpper() == post_create.denomination.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (components != null)
            {
                ModelState.AddModelError("", "Component already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var postMap = _mapper.Map<Post>(post_create);

            if (!_postRepository.CreatePost(postMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id_post}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePost(int id_post, [FromBody] PostDto post_update)
        {
            if (post_update == null)
                return BadRequest(ModelState);

            if (id_post != post_update.id_post)
                return BadRequest(ModelState);

            if (!_postRepository.PostExists(id_post))
                return BadRequest(new { message = "Error: Invalid Id" });

            if (!ModelState.IsValid)
                return BadRequest();

            var PostMap = _mapper.Map<Post>(post_update);

            if (!_postRepository.UpdatePost(PostMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id_post}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePost(int id_post)
        {
            if (!_postRepository.PostExists(id_post))
            {
                return BadRequest(new { message = "Error: Invalid Id" });
            }

            var Delete_Post = _postRepository.GetPostId(id_post);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_postRepository.DeletePost(Delete_Post))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
