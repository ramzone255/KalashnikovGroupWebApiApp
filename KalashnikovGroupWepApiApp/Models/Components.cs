using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Components
    {
        [Key]
        public int id_components { get; set; }
        public string denomination { get; set; }
        public ICollection<Operations> Operations { get; set; }
    }
}
