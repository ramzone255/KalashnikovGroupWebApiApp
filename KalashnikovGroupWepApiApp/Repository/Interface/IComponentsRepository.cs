using KalashnikovGroupWepApiApp.Models;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IComponentsRepository
    {
        ICollection<Components> GetComponents();
        Components GetComponents(int id_components);
        Components GetComponents(string denomination);
        bool ComponentsExists(int comp_id);
    }
}
