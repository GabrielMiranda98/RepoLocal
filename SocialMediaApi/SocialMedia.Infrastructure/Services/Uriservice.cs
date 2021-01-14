using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Services
{
    public class Uriservice : IUriservice
    {
        private readonly string _baseUri;

        public Uriservice(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }


    }
}
