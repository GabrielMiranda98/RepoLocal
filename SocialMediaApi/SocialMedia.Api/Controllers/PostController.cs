using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        #region Atributes
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        #endregion

        #region Ctor
        public PostController(IPostService postService, IMapper mapper,IUriService uriservice)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriservice;
        }
        #endregion

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <param name="filter">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type=typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetPosts([FromQuery]PostQueryFilter filter)
        {
            var post = _postService.GetPosts(filter);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);            
            var metadata = new Metadata{
                TotalCount = post.TotalCount,
                PageSize = post.PageSize,
                CurrentPage = post.CurrentPage,
                TotalPages = post.TotalPages,
                HasNextPage = post.HasNextPage,
                HasPreviousPage = post.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPosts))).ToString()
            };
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto) {
                meta = metadata
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
