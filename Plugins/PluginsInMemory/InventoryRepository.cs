﻿using CoreBusiness;
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
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedels", Quantity = 20, Price = 1 },
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                {
                    return Task.CompletedTask; 
                }
            
            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var inventoryToUpdate = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (inventoryToUpdate is null)
                {
                    return Task.CompletedTask;
                }
            inventoryToUpdate.InventoryName = inventory.InventoryName;
            inventoryToUpdate.Quantity = inventory.Quantity;
            inventoryToUpdate.Price = inventory.Price;
            return Task.CompletedTask;


        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
