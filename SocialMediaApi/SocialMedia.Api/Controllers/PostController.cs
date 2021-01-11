using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Atributes
        private readonly IPostRepository _postRepository;
        #endregion

        #region Ctor
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postRepository.GetPosts();
            return Ok(post);
        }
    }
}
