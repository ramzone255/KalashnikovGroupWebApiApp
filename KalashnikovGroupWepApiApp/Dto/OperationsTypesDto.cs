using KalashnikovGroupWepApiApp.Models;
using System.ComponentModel.DataAnnotations;


namespace KalashnikovGroupWepApiApp.Dto
{
    public class OperationsTypesDto
    {
        [Key]
        public int operations_types { get; set; }
        public string denomination { get; set; }
    }
}
