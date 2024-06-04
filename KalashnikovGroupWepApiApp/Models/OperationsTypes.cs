using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class OperationsTypes
    {
        [Key]
        public int operations_types {  get; set; }
        public string denomination { get; set; }
        public ICollection<Operations> Operations { get; set; }
    }
}
