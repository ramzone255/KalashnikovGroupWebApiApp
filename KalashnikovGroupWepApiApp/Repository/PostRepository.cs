using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Interface;
using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Post> GetPost()
        {
            return _context.Post.OrderBy(p => p.id_post).ToList();
        }

        public Post GetPost(int id_post)
        {
            return _context.Post.Where(p => p.id_post == id_post).FirstOrDefault();
        }

        public Post GetPost(string denomination)
        {
            return _context.Post.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool PostExists(int ps_id)
        {
            return _context.Post.Any(p => p.id_post == ps_id);
        }
    }
}
