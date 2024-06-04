using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class PaymentType
    {
        [Key]
        public int id_payments_type {  get; set; }
        public string denomination { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
