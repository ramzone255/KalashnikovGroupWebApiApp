using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IOperationsRepository
    {
        ICollection<Operations> GetOperationsCollection();
        Operations GetOperationsId(int id_operations);
        Operations GetOperationsPrice(float price);
        bool OperationsExists(int id_operations);
    }
}
