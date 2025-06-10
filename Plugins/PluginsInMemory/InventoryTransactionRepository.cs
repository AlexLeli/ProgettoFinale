using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.Interfaces;

namespace PluginsInMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public List<InventoryTransaction> _inventoryTransactions = new List<InventoryTransaction>();
        public Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InvenctoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.UtcNow,
                UnitPrice = price,

            });

            return Task.CompletedTask;
        }
    }
}
