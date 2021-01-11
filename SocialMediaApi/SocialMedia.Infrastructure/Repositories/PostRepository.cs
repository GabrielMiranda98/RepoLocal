using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestruture.Data;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;
        
        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var post = await _context.Publicacion.ToListAsync();
           return post; 
        }
    }
}
