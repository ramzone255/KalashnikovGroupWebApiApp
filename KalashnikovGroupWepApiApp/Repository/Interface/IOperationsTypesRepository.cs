using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IOperationsTypesRepository
    {
        ICollection<OperationsTypes> GetOperationsTypes();
        OperationsTypes GetOperationsTypes(int operations_types);
        OperationsTypes GetOperationsTypes(string denomination);
        bool OperationsTypesExists(int op_id);
    }
}
