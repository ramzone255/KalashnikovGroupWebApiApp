using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Interface
{
    public interface IOperationsTypesRepository
    {
        ICollection<OperationsTypes> GetOperationsTypes();
        OperationsTypes GetOperationsTypes(int operations_types);
        OperationsTypes GetOperationsTypes(string denomination);
        ICollection<Operations> GetOperationsByOperationsTypes(int Operations);
        bool OperationsTypesExists(int op_id);
    }
}
