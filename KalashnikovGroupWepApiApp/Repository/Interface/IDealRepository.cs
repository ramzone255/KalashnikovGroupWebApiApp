using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IDealRepository
    {
        ICollection<Deal> GetDealCollection();
        Deal GetDealId(int id_deal);
        Deal GetDealDate(DateTime date);
        Deal GetDealQuality(int quality);
        Deal GetDealTotalAmount(float total_amount);
        bool DealExists(int id_deal);
    }
}
