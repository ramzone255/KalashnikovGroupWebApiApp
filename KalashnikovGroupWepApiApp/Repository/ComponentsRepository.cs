using KalashnikovGroupWepApiApp.Data;
using System.ComponentModel;
using KalashnikovGroupWepApiApp.Models;
using KalashnikovGroupWepApiApp.Repository.Interface;
using AutoMapper;
using System.Diagnostics.Metrics;

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

        public ICollection<Components> GetComponentsCollection()
        {
            return _context.Components.OrderBy(p => p.id_components).ToList();
        }

        public Components GetComponentsId(int id_components)
        {
            return _context.Components.Where(p => p.id_components == id_components).FirstOrDefault();
        }

        public Components GetComponentsDenomination(string denomination)
        {
            return _context.Components.Where(p => p.denomination == denomination).FirstOrDefault();
        }

        public bool CreateComponents(Components components_create)
        {
            _context.Add(components_create);
            return Save();
        }

        public bool UpdateComponents(Components components_update)
        {
            _context.Update(components_update);
            return Save();
        }

        public bool DeleteComponents(Components components_delete)
        {
            _context.Remove(components_delete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
