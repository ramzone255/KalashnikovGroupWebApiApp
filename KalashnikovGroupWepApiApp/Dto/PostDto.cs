using KalashnikovGroupWepApiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class PostDto
    {
        [Key]
        public int id_post { get; set; }
        public string denomination { get; set; }
    }
}
