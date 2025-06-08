using CoreBusiness;

namespace UseCases.Inventories.Interfaces
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}