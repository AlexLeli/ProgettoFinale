using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}