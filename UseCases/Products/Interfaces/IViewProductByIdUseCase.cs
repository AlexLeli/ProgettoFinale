using CoreBusiness;

namespace UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product?> ExecuteAsync(int productId);
    }
}