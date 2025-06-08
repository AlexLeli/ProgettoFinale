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
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        public readonly IInventoryRepository inventoryRepository;


        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(int inventoryId)
        {
            await inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }
    }
}
