using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class OperationsTypesRepository : IOperationsTypesRepository
    {
        private readonly DataContext _context;

        public OperationsTypesRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<OperationsTypes> GetOperationsTypesCollection()
        {
            return _context.OperationsTypes.OrderBy(p => p.operations_types).ToList();
        }

        public OperationsTypes GetOperationsTypesId(int operations_types)
        {
            return _context.OperationsTypes.Where(p => p.operations_types == operations_types).FirstOrDefault();
        }

        public OperationsTypes GetOperationsTypesDenomination(string denomination)
        {
            return _context.OperationsTypes.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool OperationsTypesExists(int op_id)
        {
            return _context.OperationsTypes.Any(p => p.operations_types == op_id);
        }

        public bool CreateOperationsTypes(OperationsTypes operationstypes_create)
        {
            _context.Add(operationstypes_create);
            return Save();
        }

        public bool UpdateOperationsTypes(OperationsTypes operationstypes_update)
        {
            _context.Update(operationstypes_update);
            return Save();
        }

        public bool DeleteOperationsTypes(OperationsTypes operationstypes_delete)
        {
            _context.Remove(operationstypes_delete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
