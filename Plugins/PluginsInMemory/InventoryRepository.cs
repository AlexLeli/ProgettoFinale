using CoreBusiness;
using UseCases.Interfaces;

namespace PluginsInMemory
{
    public class InventoryRepository :IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory {}
            };
        }

        public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
