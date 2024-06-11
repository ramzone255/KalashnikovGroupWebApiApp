using KalashnikovGroupWepApiApp.Dto;
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
        ICollection<Payments> GetPaymentsOfAPaymentsType(int ptId);
        bool PaymentsExists(int payments_id);
        bool CreatePayments(Payments payments_create);
        bool UpdatePayments(Payments payments_update);
        bool DeletePayments(Payments payments_delete);
        bool Save();

    }
}
