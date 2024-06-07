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
    }
}
