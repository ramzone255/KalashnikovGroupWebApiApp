using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Deal_linking_Payday
    {
        [Key]
        public int id_payday {  get; set; }
        public int id_deal { get; set; }
        public Deal Deal { get; set; }
        public Payday Payday { get; set; }
    }
}
