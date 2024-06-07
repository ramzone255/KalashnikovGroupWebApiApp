using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IEmployeesRepository
    {
        ICollection<Employees> GetEmployeesCollection();
        Employees GetEmployeesId(int id_employess);
        Employees GetEmployeesMail(string mail);
        Employees GetEmployeesPassword(string password);
        Employees GetEmployeesName(string name);
        Employees GetEmployeesSurname(string surname);
        Employees GetEmployeesMiddlename(string middlename);
        Employees GetEmployeesWageRate(float wage_rate);
        bool EmployeesExists(int employees_id);
    }
}
