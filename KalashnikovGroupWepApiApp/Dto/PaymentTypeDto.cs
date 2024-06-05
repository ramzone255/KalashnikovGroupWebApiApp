using KalashnikovGroupWepApiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class PaymentTypeDto
    {
        [Key]
        public int id_payments_type { get; set; }
        public string denomination { get; set; }
    }
}
