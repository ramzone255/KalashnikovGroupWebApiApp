using KalashnikovGroupWepApiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class PaymentsDto
    {
        [Key]
        public int id_payments { get; set; }
        public float amount { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
    }
}
