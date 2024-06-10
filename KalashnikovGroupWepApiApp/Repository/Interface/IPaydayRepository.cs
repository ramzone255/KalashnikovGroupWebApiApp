using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPaydayRepository
    {
        ICollection<Payday> GetPaydayCollection();
        Payday GetPaydayId(int id_payday);
        Payday GetPaydayPaycheck(float paycheck);
        Payday GetPaydayEndDate(DateTime end_date);
        Payday GetPaydayStartDate(DateTime start_date);
        bool PaydayExists(int id_payday);
    }
}
