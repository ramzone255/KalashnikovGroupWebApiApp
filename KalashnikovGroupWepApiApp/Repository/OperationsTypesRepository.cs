using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Interface;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class OperationsTypesRepository : IOperationsTypesRepository
    {
        private readonly DataContext _context;

        public OperationsTypesRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<OperationsTypes> GetOperationsTypes()
        {
            return _context.OperationsTypes.OrderBy(p => p.operations_types).ToList();
        }

        public OperationsTypes GetOperationsTypes(int operations_types)
        {
            return _context.OperationsTypes.Where(p => p.operations_types == operations_types).FirstOrDefault();
        }

        public OperationsTypes GetOperationsTypes(string denomination)
        {
            return _context.OperationsTypes.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool OperationsTypesExists(int op_id)
        {
            return _context.OperationsTypes.Any(p => p.operations_types == op_id);
        }
    }
}
