using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Payday
    {
        [Key]
        public int id_payday {  get; set; }
        public float paycheck { get; set; }
        public DateTime end_date { get; set; }
        public DateTime start_date { get; set; }
        public ICollection<Deal_linking_Payday> Deal_linking_Payday { get; set; }
        public ICollection<Payday_linking_Payments> Payday_linking_Payments { get; set; }
    }
}
