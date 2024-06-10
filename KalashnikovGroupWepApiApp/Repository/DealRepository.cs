using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class DealRepository : IDealRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DealRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DealExists(int id_deal)
        {
            return _context.Deal.Any(p => p.id_deal == id_deal);
        }

        public ICollection<Deal> GetDealCollection()
        {
            return _context.Deal.OrderBy(p => p.id_deal).ToList();
        }

        public Deal GetDealDate(DateTime date)
        {
            return _context.Deal.Where(p => p.date == date).FirstOrDefault();
        }

        public Deal GetDealId(int id_deal)
        {
            return _context.Deal.Where(p => p.id_deal == id_deal).FirstOrDefault();
        }

        public Deal GetDealQuality(int quality)
        {
            return _context.Deal.Where(p => p.quality == quality).FirstOrDefault();
        }

        public Deal GetDealTotalAmount(float total_amount)
        {
            return _context.Deal.Where(p => p.total_amount == total_amount).FirstOrDefault();
        }
    }
}
