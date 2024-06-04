using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Interface
{
    public interface IPostRepository
    {
        ICollection<Post> GetPost();
        Post GetPost(int id_post);
        Post GetPost(string denomination);
        bool PostExists(int ps_id);
    }
}
