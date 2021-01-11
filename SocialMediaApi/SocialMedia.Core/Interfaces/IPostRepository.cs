using SocialMedia.Core.Entities;
using SocialMedia.Infraestruture.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Publicacion>> GetPosts();
    }
}
