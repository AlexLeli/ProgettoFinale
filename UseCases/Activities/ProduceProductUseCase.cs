using CoreBusiness;
using UseCases.Activities.Interfaces;
using UseCases.Interfaces;

namespace UseCases.Activities
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IProductTransactionRepository productTransactionRepository;

        public ProduceProductUseCase(IProductRepository productRepository, IProductTransactionRepository productTransactionRepository)
        {
            this.productRepository = productRepository;
            this.productTransactionRepository = productTransactionRepository;
        }
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            //add transaction record
            await this.productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneBy);

            //decrease the quantity inventories

            //update the quantity of product
            product.Quantity += quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}