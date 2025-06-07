using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.Inventories.Interfaces;

namespace UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        public readonly IInventoryRepository inventoryRepository;


        public AddInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            await inventoryRepository.AddInventoryAsync(inventory);
        }
    }
}
