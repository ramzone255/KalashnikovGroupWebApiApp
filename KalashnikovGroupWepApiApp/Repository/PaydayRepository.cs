using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class PaydayRepository : IPaydayRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaydayRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Payday> GetPaydayCollection()
        {
            return _context.Payday.OrderBy(p => p.id_payday).ToList();
        }

        public Payday GetPaydayEndDate(DateTime end_date)
        {
            return _context.Payday.Where(p => p.end_date == end_date).FirstOrDefault();
        }

        public Payday GetPaydayId(int id_payday)
        {
            return _context.Payday.Where(p => p.id_payday == id_payday).FirstOrDefault();
        }

        public Payday GetPaydayPaycheck(float paycheck)
        {
            return _context.Payday.Where(p => p.paycheck == paycheck).FirstOrDefault();
        }

        public Payday GetPaydayStartDate(DateTime start_date)
        {
            return _context.Payday.Where(p => p.start_date == start_date).FirstOrDefault();
        }

        public bool PaydayExists(int id_payday)
        {
            return _context.Payday.Any(p => p.id_payday == id_payday);
        }
    }
}
