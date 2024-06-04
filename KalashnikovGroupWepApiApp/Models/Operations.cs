using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Operations
    {
        [Key]
        public int id_operations {  get; set; }
        public float price {  get; set; }
        public Components Components { get; set; }
        public OperationsTypes OperationsTypes { get; set; }
        public ICollection<Deal> Deal { get; set; }
    }
}
