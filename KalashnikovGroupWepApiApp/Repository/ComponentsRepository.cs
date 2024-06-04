using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Interface;

namespace KalashnikovGroupWepApiApp.Repository
{
    public class ComponentsRepository : IComponentsRepository
    {
        private readonly DataContext _context;

        public ComponentsRepository(DataContext context)
        {
            _context = context;
        }

        public bool ComponentsExists(int comp_id)
        {
            return _context.Components.Any(p => p.id_components == comp_id);
        }

        public ICollection<Components> GetComponents()
        {
            return _context.Components.OrderBy(p => p.id_components).ToList();
        }

        public Components GetComponents(int id_components)
        {
            return _context.Components.Where(p => p.id_components == id_components).FirstOrDefault();
        }

        public Components GetComponents(string denomination)
        {
            return _context.Components.Where(p => p.denomination == denomination).FirstOrDefault();
        }
    }
}
