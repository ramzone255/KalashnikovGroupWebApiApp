using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Payday_linking_Payments
    {
        [Key]
        public int id_payments {  get; set; }
        public int id_payday { get; set; }
        public Payments Payments { get; set; }
        public Payday Payday { get; set; }
    }
}
