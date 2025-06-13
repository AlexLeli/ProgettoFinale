using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.Activities.Interfaces;
using UseCases.Interfaces;

namespace UseCases.Activities
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;

        private readonly IInventoryRepository inventoryRepository;

        public PurchaseInventoryUseCase(IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            //insert a record in the transaction table
            await inventoryTransactionRepository.PurchaseAsync(poNumber, inventory, quantity, doneBy, inventory.Price);
            //increase the quantity
            inventory.Quantity += quantity;
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
