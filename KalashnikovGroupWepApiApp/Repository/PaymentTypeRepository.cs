using AutoMapper;
using KalashnikovGroupWepApiApp.Data;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly DataContext _context;
        public PaymentTypeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<PaymentType> GetPaymentType()
        {
            return _context.PaymentType.OrderBy(p => p.id_payments_type).ToList();
        }

        public PaymentType GetPaymentType(int id_payments_type)
        {
            return _context.PaymentType.Where(p => p.id_payments_type == id_payments_type).FirstOrDefault();
        }

        public PaymentType GetPaymentType(string denomination)
        {
            return _context.PaymentType.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool PaymentTypeExists(int pt_id)
        {
            return _context.PaymentType.Any(p => p.id_payments_type == pt_id);
        }
    }
}
