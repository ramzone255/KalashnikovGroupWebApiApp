using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }


        public ICollection<Post> GetPostCollection()
        {
            return _context.Post.OrderBy(p => p.id_post).ToList();
        }

        public Post GetPostId(int id_post)
        {
            return _context.Post.Where(p => p.id_post == id_post).FirstOrDefault();
        }

        public Post GetPostDenomination(string denomination)
        {
            return _context.Post.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool PostExists(int ps_id)
        {
            return _context.Post.Any(p => p.id_post == ps_id);
        }
    }
}
