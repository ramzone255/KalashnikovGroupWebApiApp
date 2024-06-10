using KalashnikovGroupWepApiApp.Models;
using System.Diagnostics.Metrics;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPostRepository
    {
        ICollection<Post> GetPostCollection();
        Post GetPostId(int id_post);
        Post GetPostDenomination(string denomination);
        bool PostExists(int ps_id);
        bool CreatePost(Post post_create);
        bool UpdatePost(Post post_update);
        bool DeletePost(Post post_delete);
        bool Save();
    }
}

