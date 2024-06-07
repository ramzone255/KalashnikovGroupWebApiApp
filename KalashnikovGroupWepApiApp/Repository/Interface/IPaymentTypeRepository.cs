using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPaymentTypeRepository
    {
        ICollection<PaymentType> GetPaymentTypeCollection();
        PaymentType GetPaymentTypeId(int id_payments_type);
        PaymentType GetPaymentTypeDenomination(string denomination);
        bool PaymentTypeExists(int pt_id);
    }
}
