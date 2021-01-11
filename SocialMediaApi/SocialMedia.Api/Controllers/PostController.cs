using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestruture.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Atributes
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper; 
        #endregion

        #region Ctor
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postRepository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);
            return Ok(postsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosts(int id)
        {
            var post = await _postRepository.GetPosts(id);
            var postsDto = _mapper.Map<PostDto>(post);
            return Ok(postsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postsDto)
        {
            var post = _mapper.Map<Post>(postsDto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}
