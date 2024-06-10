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

        public bool CreatePost(Post post_create)
        {
            _context.Add(post_create);
            return Save();
        }

        public bool UpdatePost(Post post_update)
        {
            _context.Update(post_update);
            return Save();
        }

        public bool DeletePost(Post post_delete)
        {
            _context.Remove(post_delete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
