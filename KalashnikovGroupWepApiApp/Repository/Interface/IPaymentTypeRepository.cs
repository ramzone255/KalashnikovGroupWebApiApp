using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPaymentTypeRepository
    {
        ICollection<PaymentType> GetPaymentType();
        PaymentType GetPaymentType(int id_payments_type);
        PaymentType GetPaymentType(string denomination);
        bool PaymentTypeExists(int pt_id);
    }
}
