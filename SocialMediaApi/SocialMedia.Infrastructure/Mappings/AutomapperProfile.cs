using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Infraestruture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post,PostDto>();
            CreateMap<PostDto,Post>();
        }
    }
}
