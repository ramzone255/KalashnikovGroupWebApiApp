using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Payments
    {
        [Key]
        public int id_payments {  get; set; }
        public float amount { get; set; }
        public DateTime date {  get; set; }
        public string description { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<Payday_linking_Payments> Payday_linking_Payments { get; set; }
    }
}
