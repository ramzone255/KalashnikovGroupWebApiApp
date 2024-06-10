using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IOperationsTypesRepository
    {
        ICollection<OperationsTypes> GetOperationsTypesCollection();
        OperationsTypes GetOperationsTypesId(int operations_types);
        OperationsTypes GetOperationsTypesDenomination(string denomination);
        bool OperationsTypesExists(int op_id);
        bool CreateOperationsTypes(OperationsTypes operationstypes_create);
        bool UpdateOperationsTypes(OperationsTypes operationstypes_update);
        bool DeleteOperationsTypes(OperationsTypes operationstypes_delete);
        bool Save();
    }
}
