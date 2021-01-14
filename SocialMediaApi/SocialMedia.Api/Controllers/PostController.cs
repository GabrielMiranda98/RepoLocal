using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        #region Atributes
        private readonly IPostService _postService;

        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetPosts([FromQuery]PostQueryFilter filter)
        {
            var post = _postService.GetPosts(filter);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);

            var metadata = new { 

            post.TotalCount,
            post.PageSize,
            post.CurrentPage,
            post.TotalPages,
            post.HasNextPage,
            post.HasPreviousPage

            };
            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPosts(id);
            var postsDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postsDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = _mapper.Map<Post>(postsDto);
            await _postService.InsertPost(post);
            postsDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postsDto);
            return Ok(response);

        }
        [HttpPut] //Actualizar un nuevo recurso
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
