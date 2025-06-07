using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases.Inventories
{
    public class ViewInventoriesByNameUseCase
    {
        public readonly IInventoryRepository inventoryRepository;

        
        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository) 
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
