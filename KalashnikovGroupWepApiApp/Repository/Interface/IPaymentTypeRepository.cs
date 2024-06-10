using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IPaymentTypeRepository
    {
        ICollection<PaymentType> GetPaymentTypeCollection();
        PaymentType GetPaymentTypeId(int id_payments_type);
        PaymentType GetPaymentTypeDenomination(string denomination);
        bool PaymentTypeExists(int pt_id);
        bool CreatePaymentType(PaymentType paymenttype_create);
        bool UpdatePaymentType(PaymentType paymenttype_update);
        bool DeletePaymentType(PaymentType paymenttype_delete);
        bool Save();
    }
}
