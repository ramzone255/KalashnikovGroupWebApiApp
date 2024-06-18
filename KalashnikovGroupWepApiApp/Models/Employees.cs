using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Models
{
    public class Employees
    {
        [Key]
        public int id_employess { get; set; }
        public string mail {  get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string middlename { get; set; }
        public float wage_rate { get; set; }
        public Post Post { get; set; }
        public int Postid_post { get; set; }
        public ICollection<Deal> Deal { get; set; }
    }
}
