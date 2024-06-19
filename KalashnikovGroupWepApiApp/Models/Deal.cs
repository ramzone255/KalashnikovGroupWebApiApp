using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Deal
    {
        [Key]
        public int id_deal {  get; set; }
        public DateTime date {  get; set; }
        public int quality { get; set; }
        public float total_amount { get; set; }
        public int Employeesid_employess { get; set; }
        public int Operationsid_operations { get; set; }
        public Employees Employees { get; set; }
        public Operations Operations { get; set; }
        public ICollection<Deal_linking_Payday> Deal_linking_Payday { get; set; }

    }
}
