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
        ICollection<Employees> GetEmployeesOfAPosts(int id_post);
        bool EmployeesExists(int employees_id);
        bool CreateEmployees(Employees employees_create);
        bool UpdateEmployees(Employees employees_update);
        bool DeleteEmployees(Employees employees_delete);
        bool Save();
    }
}
