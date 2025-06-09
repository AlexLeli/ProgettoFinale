using CoreBusiness;

namespace UseCases.Products.Interfaces
{
    public interface IUpdateProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}