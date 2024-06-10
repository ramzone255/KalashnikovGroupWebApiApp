using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaymentsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Payments GetPaymentsAmount(float amount)
        {
            return _context.Payments.Where(p => p.amount == amount).FirstOrDefault();
        }

        public ICollection<Payments> GetPaymentsCollection()
        {
            return _context.Payments.OrderBy(p => p.id_payments).ToList();
        }

        public Payments GetPaymentsDate(DateTime date)
        {
            return _context.Payments.Where(p => p.date == date).FirstOrDefault();
        }

        public Payments GetPaymentsDescription(string description)
        {
            return _context.Payments.Where(p => p.description == description).FirstOrDefault();
        }

        public Payments GetPaymentsId(int id_payments)
        {
            return _context.Payments.Where(p => p.id_payments == id_payments).FirstOrDefault();
        }

        public bool PaymentsExists(int payments_id)
        {
            return _context.Payments.Any(p => p.id_payments == payments_id);
        }
    }

}
