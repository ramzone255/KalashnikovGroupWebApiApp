using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class OperationsRepository : IOperationsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OperationsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateOperations(Operations operations_create)
        {
            _context.Add(operations_create);
            return Save();
        }

        public bool DeleteOperations(Operations operationss_delete)
        {
            _context.Remove(operationss_delete);
            return Save();
        }

        public ICollection<Operations> GetOperationsCollection()
        {
            return _context.Operations.OrderBy(p => p.id_operations).ToList();
        }

        public Operations GetOperationsId(int id_operations)
        {
            return _context.Operations.Where(p => p.id_operations == id_operations).FirstOrDefault();
        }

        public ICollection<Operations> GetOperationsOfAComponents(int comId)
        {
            return _context.Operations.Where(r => r.Components.id_components == comId).ToList();
        }

        public ICollection<Operations> GetOperationsOfAOperationsTypes(int otId)
        {
            return _context.Operations.Where(r => r.OperationsTypes.operations_types == otId).ToList();
        }

        public Operations GetOperationsPrice(float price)
        {
            return _context.Operations.Where(p => p.price == price).FirstOrDefault();
        }

        public bool OperationsExists(int id_operations)
        {
            return _context.Operations.Any(p => p.id_operations == id_operations);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOperations(Operations operations_update)
        {
            _context.Update(operations_update);
            return Save();
        }
    }
}
