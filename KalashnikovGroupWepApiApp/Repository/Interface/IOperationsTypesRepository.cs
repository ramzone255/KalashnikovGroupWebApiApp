using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IOperationsTypesRepository
    {
        ICollection<OperationsTypes> GetOperationsTypesCollection();
        OperationsTypes GetOperationsTypesId(int operations_types);
        OperationsTypes GetOperationsTypesDenomination(string denomination);
        bool OperationsTypesExists(int op_id);
    }
}
