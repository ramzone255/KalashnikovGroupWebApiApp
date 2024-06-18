using System.ComponentModel.DataAnnotations;

namespace KalashnikovGroupWepApiApp.Dto
{
    public class OperationsDto
    {
        [Key]
        public int id_operations { get; set; }
        public float price { get; set; }
        public int Componentsid_components { get; set; }
        public int OperationsTypesoperations_types { get; set; }
    }
}
