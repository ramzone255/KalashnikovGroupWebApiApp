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

        public ICollection<Operations> GetOperationsCollection()
        {
            return _context.Operations.OrderBy(p => p.id_operations).ToList();
        }

        public Operations GetOperationsId(int id_operations)
        {
            return _context.Operations.Where(p => p.id_operations == id_operations).FirstOrDefault();
        }

        public Operations GetOperationsPrice(float price)
        {
            return _context.Operations.Where(p => p.price == price).FirstOrDefault();
        }

        public bool OperationsExists(int id_operations)
        {
            return _context.Operations.Any(p => p.id_operations == id_operations);
        }
    }
}
