using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPaymentsRepository
    {
        ICollection<Payments> GetPaymentsCollection();
        Payments GetPaymentsId(int id_payments);
        Payments GetPaymentsAmount(float amount);
        Payments GetPaymentsDate(DateTime date);
        Payments GetPaymentsDescription(string description);
        bool PaymentsExists(int payments_id);

    }
}
