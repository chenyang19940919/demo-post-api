using demo_post_api.Models;
using demo_post_api.Repository;
using demo_post_api.Services.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_post_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _postService.GetPostListAsync();
                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var data = await _postService.GetPostAsync(id);
                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post newPost)
        {
            try
            {
                await _postService.CreatePostAsync(newPost);
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Post updatePost)
        {
            try
            {
                var data = await _postService.GetPostAsync(id);

                if (data == null)
                {
                    throw new Exception("Invalid ID");
                }

                await _postService.UpdatePostAsync(id, updatePost);
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var data = await _postService.GetPostAsync(id);

                if (data == null)
                {
                    throw new Exception("Invalid ID");
                }

                await _postService.DeletePostAsync(id);
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
