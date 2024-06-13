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

        public bool CreateDeal(Deal deal_create)
        {
            _context.Add(deal_create);
            return Save();
        }

        public bool DealExists(int id_deal)
        {
            return _context.Deal.Any(p => p.id_deal == id_deal);
        }

        public bool DeleteDeal(Deal deal_delete)
        {
            _context.Remove(deal_delete);
            return Save();
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

        public ICollection<Deal> GetDealOfAEmployees(int id_employees)
        {
            return _context.Deal.Where(r => r.Employees.id_employess == id_employees).ToList();
        }

        public ICollection<Deal> GetDealOfAOperations(int id_operations)
        {
            return _context.Deal.Where(r => r.Operations.id_operations == id_operations).ToList();
        }

        public Deal GetDealQuality(int quality)
        {
            return _context.Deal.Where(p => p.quality == quality).FirstOrDefault();
        }

        public Deal GetDealTotalAmount(float total_amount)
        {
            return _context.Deal.Where(p => p.total_amount == total_amount).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDeal(Deal deal_update)
        {
            _context.Update(deal_update);
            return Save();
        }
    }
}
