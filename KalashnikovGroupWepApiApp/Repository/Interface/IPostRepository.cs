using KalashnikovGroupWepApiApp.Models;
using System.Diagnostics.Metrics;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPostRepository
    {
        ICollection<Post> GetPost();
        Post GetPost(int id_post);
        Post GetPost(string denomination);
        ICollection<Employees> GetEmployeesFromAPost(int postId);
        Post GetPostByEmployees(int employeesId);
        bool PostExists(int ps_id);
    }
}
