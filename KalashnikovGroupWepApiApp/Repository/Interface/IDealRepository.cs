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
        ICollection<Deal> GetDealOfAEmployees(int id_employees);
        ICollection<Deal> GetDealOfAOperations(int id_operations);
        bool DealExists(int id_deal);
        bool CreateDeal(Deal deal_create);
        bool UpdateDeal(Deal deal_update);
        bool DeleteDeal(Deal deal_delete);
        bool Save();
    }
}
