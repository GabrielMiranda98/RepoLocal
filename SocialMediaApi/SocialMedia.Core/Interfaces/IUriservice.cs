using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Core.Interfaces
{
    public interface IUriservice
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}