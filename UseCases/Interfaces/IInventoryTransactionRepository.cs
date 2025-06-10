using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);
    }
}