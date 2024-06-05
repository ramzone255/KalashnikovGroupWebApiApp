using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool EmployeesExists(int employees_id)
        {
            return _context.Employees.Any(p => p.id_employess == employees_id);
        }

        public ICollection<Deal> GetDealFromAEmployees(int employeesId)
        {
            return _context.Deal.Where(c => c.Employees.id_employess == employeesId).ToList();
        }

        public ICollection<Employees> GetEmployees()
        {
            return _context.Employees.OrderBy(p => p.id_employess).ToList();
        }

        public Employees GetEmployees(int id_employess)
        {
            return _context.Employees.Where(p => p.id_employess == id_employess).FirstOrDefault();
        }

        public Employees GetEmployeesByDeal(int dealId)
        {
            return _context.Deal.Where(o => o.id_deal == dealId).Select(c => c.Employees).FirstOrDefault();
        }

        public Employees GetEmployeesMail(string mail)
        {
            return _context.Employees.Where(p => p.mail == mail).FirstOrDefault();
        }

        public Employees GetEmployeesMiddlename(string middlename)
        {
            return _context.Employees.Where(p => p.middlename == middlename).FirstOrDefault();
        }

        public Employees GetEmployeesName(string name)
        {
            return _context.Employees.Where(p => p.name == name).FirstOrDefault();
        }

        public Employees GetEmployeesPassword(string password)
        {
            return _context.Employees.Where(p => p.password == password).FirstOrDefault();
        }

        public Employees GetEmployeesSurname(string surname)
        {
            return _context.Employees.Where(p => p.surname == surname).FirstOrDefault();
        }

        public Employees GetEmployeesWageRate(float wage_rate)
        {
            return _context.Employees.Where(p => p.wage_rate == wage_rate).FirstOrDefault();
        }

        public ICollection<Post> GetPostFromADeal(int gpfad_id)
        {
            throw new NotImplementedException();
        }
    }
}
