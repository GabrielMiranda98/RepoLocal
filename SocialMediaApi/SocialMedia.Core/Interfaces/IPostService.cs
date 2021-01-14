﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts(PostQueryFilter filter);
        Task<Post> GetPosts(int id);

        Task InsertPost(Post post);

        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}