using SocialMedia.Infraestruture.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Infraestruture.Data.Post>> GetPosts();
        Task<Post> GetPosts(int id);

    }
}
