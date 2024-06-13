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

        public bool CreateEmployees(Employees employees_create)
        {
            _context.Add(employees_create);
            return Save();
        }

        public bool DeleteEmployees(Employees employees_delete)
        {
            _context.Remove(employees_delete);
            return Save();
        }

        public bool EmployeesExists(int employees_id)
        {
            return _context.Employees.Any(p => p.id_employess == employees_id);
        }

        public ICollection<Employees> GetEmployeesCollection()
        {
            return _context.Employees.OrderBy(p => p.id_employess).ToList();
        }

        public Employees GetEmployeesId(int id_employess)
        {
            return _context.Employees.Where(p => p.id_employess == id_employess).FirstOrDefault();
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

        public ICollection<Employees> GetEmployeesOfAPosts(int id_post)
        {
            return _context.Employees.Where(r => r.Post.id_post == id_post).ToList();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEmployees(Employees employees_update)
        {
            _context.Update(employees_update);
            return Save();
        }
    }
}
