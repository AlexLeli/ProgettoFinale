﻿using CoreBusiness;

namespace UseCases.Reports.Interfaces
{
    public interface ISearchInventoryTransactionUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InvenctoryTransactionType? transactionType);
    }
}