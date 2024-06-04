using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Post
    {
        [Key]
        public int id_post { get; set; }
        public string denomination { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
