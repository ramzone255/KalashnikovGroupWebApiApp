using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IOperationsRepository
    {
        ICollection<Operations> GetOperationsCollection();
        Operations GetOperationsId(int id_operations);
        Operations GetOperationsPrice(float price);
        ICollection<Operations> GetOperationsOfAOperationsTypes(int otId);
        ICollection<Operations> GetOperationsOfAComponents(int comId);
        bool OperationsExists(int id_operations);
        bool CreateOperations(Operations operations_create);
        bool UpdateOperations(Operations operations_update);
        bool DeleteOperations(Operations operationss_delete);
        bool Save();
    }
}
