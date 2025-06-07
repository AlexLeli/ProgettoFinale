using CoreBusiness;

namespace UseCases.Inventories.Interfaces
{
    public interface IUpdateInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}