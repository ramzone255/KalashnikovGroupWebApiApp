using KalashnikovGroupWepApiApp.Models;
using System.Diagnostics.Metrics;

namespace KalashnikovGroupWepApiApp.Repository.Interface
{
    public interface IComponentsRepository
    {
        ICollection<Components> GetComponentsCollection();
        Components GetComponentsId(int id_components);
        Components GetComponentsDenomination(string denomination);
        bool ComponentsExists(int comp_id);
        bool CreateComponents(Components components_create);
        bool UpdateComponents(Components components_update);
        bool DeleteComponents(Components components_delete);
        bool Save();
    }
}
