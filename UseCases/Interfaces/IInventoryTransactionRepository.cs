﻿using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);

        Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price);
        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InvenctoryTransactionType? transactionType);
    }
}