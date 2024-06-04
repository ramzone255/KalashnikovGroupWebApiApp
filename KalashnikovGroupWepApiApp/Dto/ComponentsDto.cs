using KalashnikovGroupWepApiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class ComponentsDto
    {
        [Key]
        public int id_components { get; set; }
        public string denomination { get; set; }
    }
}
