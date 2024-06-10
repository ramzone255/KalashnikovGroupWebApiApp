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

        public ICollection<PaymentType> GetPaymentTypeCollection()
        {
            return _context.PaymentType.OrderBy(p => p.id_payments_type).ToList();
        }

        public PaymentType GetPaymentTypeId(int id_payments_type)
        {
            return _context.PaymentType.Where(p => p.id_payments_type == id_payments_type).FirstOrDefault();
        }

        public PaymentType GetPaymentTypeDenomination(string denomination)
        {
            return _context.PaymentType.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool PaymentTypeExists(int pt_id)
        {
            return _context.PaymentType.Any(p => p.id_payments_type == pt_id);
        }

        public bool CreatePaymentType(PaymentType paymenttype_create)
        {
            _context.Add(paymenttype_create);
            return Save();
        }

        public bool UpdatePaymentType(PaymentType paymenttype_update)
        {
            _context.Update(paymenttype_update);
            return Save();
        }

        public bool DeletePaymentType(PaymentType paymenttype_delete)
        {
            _context.Remove(paymenttype_delete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
