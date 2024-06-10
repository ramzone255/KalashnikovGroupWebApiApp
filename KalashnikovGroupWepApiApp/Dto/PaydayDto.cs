using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class PaydayDto
    {
        [Key]
        public int id_payday { get; set; }
        public float paycheck { get; set; }
        public DateTime end_date { get; set; }
        public DateTime start_date { get; set; }
    }
}
